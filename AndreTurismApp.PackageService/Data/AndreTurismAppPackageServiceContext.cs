using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreTurismoApp.Models;

namespace AndreTurismApp.PackageService.Data
{
    public class AndreTurismAppPackageServiceContext : DbContext
    {
        public AndreTurismAppPackageServiceContext (DbContextOptions<AndreTurismAppPackageServiceContext> options)
            : base(options)
        {
        }

        public DbSet<AndreTurismoApp.Models.Package> Package { get; set; } = default!;
    }
}
