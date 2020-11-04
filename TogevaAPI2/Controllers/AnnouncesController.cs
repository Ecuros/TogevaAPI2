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
        [HttpGet]
        [Authorize]
        public List<Announce> getAnnounces()
        {

            return new List<Announce>(context.Announces);
        }
        [HttpGet("{city}")]
        
        public List<Announce> getAnnouncesByCity(string city)
        {
            return new List<Announce>(context.Announces.Where(a => a.location == city));
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
            //User user = (context.Users.Where(u => u.Email == "dupa3")).FirstOrDefault();           
            context.Announces.Add(model);
            context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

    }
}
