using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TheSpacePort
{
    public class SpacePortContext : DbContext
    {
        public DbSet<Parking> parkings { get; set; }
        public DbSet<Person> persons { get; set; }
        public DbSet<Starship> starships { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var EnvironmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            IConfiguration config = new ConfigurationBuilder()
                  .AddJsonFile("appsettings.json", true, true)
                  .AddJsonFile($"appsettings.Development.json", true, true)
                  .Build();


            optionsBuilder.UseSqlServer(config["ConnectionStrings:DefaultConnection"]);
        }
    }
}
