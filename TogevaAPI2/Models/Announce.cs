using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TogevaAPI2.Models
{
    public class Announce
    {
        public int AnnounceId { get; set; }
        public string location { get; set; }
        public string description { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

    }
}
