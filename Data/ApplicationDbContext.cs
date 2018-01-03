using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Violet.Entities;

namespace Violet.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<VideoType> VideoTypes { get; set; }
        public DbSet<VideoCategory> VideoCategories { get; set; }

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}
