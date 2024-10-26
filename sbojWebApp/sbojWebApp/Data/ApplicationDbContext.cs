using Microsoft.EntityFrameworkCore;
using sbojWebApp.Models;

namespace sbojWebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<JobPosition> JobPositions { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

    }
}
