using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreTurismoApp.Models;

namespace AndreTurismoApp.AirfareService.Data
{
    public class AndreTurismoAppAirfareServiceContext : DbContext
    {
        public AndreTurismoAppAirfareServiceContext (DbContextOptions<AndreTurismoAppAirfareServiceContext> options)
            : base(options)
        {
        }

        public DbSet<AndreTurismoApp.Models.Airfare> Airfare { get; set; } = default!;
    }
}
