using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace retro_api
{
    public class PotterContext : DbContext, IPotterContext
    {
        private readonly IConfiguration Config;
        public DbSet<House> houses { get; set; }

        //public PotterContext(IConfiguration config)
        //{
        //    Config = config;
           
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseNpgsql("Host=localhost;Database=harry_potter;Username=northcoders;Password=password");
        }


        private string BuildConfigString(string host, string db, string username, string pw)
        {
            return $"Host={host};Database={db};Username={username};Password={pw}";
        }
    }


}
