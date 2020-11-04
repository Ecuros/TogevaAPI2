using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TogevaAPI2.Migrations;

namespace TogevaAPI2.Models
{
    public class TogevaDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Announce> Announces { get; set; }
        //public DbSet<LoginModel> loginModels { get; set; }
        /*protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Togeva;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }*/
        public TogevaDBContext(DbContextOptions<TogevaDBContext> options):base(options)
        {
            
        }
    }
}
