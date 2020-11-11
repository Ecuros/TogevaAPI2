using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using TogevaAPI2.Models;

namespace TogevaAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncesController : ControllerBase
    {
        private TogevaDBContext context;
        private IConfiguration configuration;
        public AnnouncesController(TogevaDBContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }
        [HttpPost("get")]
        [Authorize]
        public List<Announce> getAnnounces(User user)
        {

            return new List<Announce>(context.Announces.Where(u => u.UserId != user.Id));
        }

        [HttpPost("filter")]        
        public List<Announce> getAnnouncesByCity([FromBody]Announce announce)
        {
            if (!String.IsNullOrEmpty(announce.sport) && !String.IsNullOrEmpty(announce.location) )
            {
                return new List<Announce>(context.Announces.Where(a => a.location == announce.location && a.sport == announce.sport && a.date.Day == announce.date.Day));
            }
            else if (!String.IsNullOrEmpty(announce.location))
            {
                return new List<Announce>(context.Announces.Where(a => a.location == announce.location && a.date.Day == announce.date.Day));
            }
            else if (!String.IsNullOrEmpty(announce.sport))
            {
                return new List<Announce>(context.Announces.Where(a => a.sport == announce.sport && a.date.Day == announce.date.Day));
            }
            else return null;

        }
        [HttpPost("user")]
        public List<Announce> getAnnouncesByUser([FromBody] User user)
        {
            return new List<Announce>(context.Announces.Where(a => a.UserId == user.Id));
        }

        [HttpPost]
        public void putAnnounce([FromBody] Announce model)
        {
            try { 
            //User user = (context.Users.Where(u => u.Email == "a")).FirstOrDefault();           
            context.Announces.Add(model);
            context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        [HttpPost("delete")]
        public List<Announce> deleteAnnounce([FromBody] Announce model)
        {
            try
            {
                //User user = (context.Users.Where(u => u.Email == "a")).FirstOrDefault();           
                context.Announces.Remove(model);
                context.SaveChanges();
                return new List<Announce>(context.Announces);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
