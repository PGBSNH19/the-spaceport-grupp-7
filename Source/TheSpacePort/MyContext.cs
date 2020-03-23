using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TheSpacePort
{
    public class MyContext : DbContext
    {
        public DbSet<Parking> parkings { get; set; }
        public DbSet<Person> people { get; set; }
        public DbSet<Vehicle> vehicles { get; set; }
        public DbSet<SpacePort> spacePorts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            IConfiguration config = new ConfigurationBuilder()
                  .AddJsonFile("appsettings.json", true, true)
                  .AddJsonFile("appsettings.dev.json", true, true)
                  .Build();


            optionsBuilder.UseSqlServer(config["ConnectionStrings:DefaultConnection"]);
        }
    }
}
