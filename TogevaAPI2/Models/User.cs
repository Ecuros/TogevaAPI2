using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace TogevaAPI2.Models
{
    public class User : IdentityUser
    {
        public int UserId { get; set; }
        //public string email { get; set; }
        public string password { get; set; }

        public List<Announce> Announces { get; set; }

        public string newPassword { get; set; }
        public string firstName { get; set; }
      
    }
}
