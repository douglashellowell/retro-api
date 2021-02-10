using System;
using Microsoft.EntityFrameworkCore;

namespace retro_api
{
    public interface IPotterContext
    {
        public DbSet<House> houses { get; set; }
    }
}
