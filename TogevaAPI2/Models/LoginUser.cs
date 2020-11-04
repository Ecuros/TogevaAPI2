using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TogevaAPI2.Models
{
    public class LoginUser : IdentityUser
    {
        public int UserId { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
