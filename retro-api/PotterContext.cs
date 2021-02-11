using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace retro_api
{
    public class PotterContext : DbContext, IPotterContext
    {
        // db config
        private string host;
        private string db;
        private string username;
        private string password;

        // db fields
        public DbSet<House> houses { get; set; }

        public PotterContext(IConfiguration config)
        {
            LoadConfig(config);
        }

        private void LoadConfig(IConfiguration config)
        {
            host = config.GetValue<string>("dbConfig:host");
            db = config.GetValue<string>("dbConfig:database");
            host = config.GetValue<string>("dbConfig:host");
            host = config.GetValue<string>("dbConfig:host");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string configString = BuildConfigString();
            optionsBuilder.UseNpgsql("Host=localhost;Database=harry_potter;Username=northcoders;Password=password");
        }

        private string BuildConfigString()
        {
            return $"Host={host};Database={db};Username={username};Password={password}";
        }
    }


}
