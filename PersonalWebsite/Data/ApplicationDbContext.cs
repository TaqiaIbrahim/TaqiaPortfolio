using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaqiaPortFolio.Models;

namespace TaqiaPortFolio.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().ToTable("Users", "Security");
            builder.Entity<IdentityRole>().ToTable("Roles", "Security");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim", "Security");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin", "Security");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim", "Security");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserToken", "Security");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRole", "Security");




        }
       

       
        public DbSet<AboutMe> AboutMe { get; set; }
        public DbSet<Training> Training { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ClientOpinion> ClientOpinion { get; set; }
        public DbSet<Gallery> Gallery { get; set; }
        public DbSet<Expericence> Expericence { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Slider> Slider { get; set; }


    }
}