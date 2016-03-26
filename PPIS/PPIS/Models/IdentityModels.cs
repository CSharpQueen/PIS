using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PPIS.Models
{
    public enum Role {
        User, ChangeManager, Cab
    }
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        
        public string ImeIPrezime { get; set; }        
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }        
        public DbSet <Dobavljac> Dobavljac { get; set; }
        public DbSet<Ponuda> Ponuda { get; set; }
        public DbSet<Potraznja> Potraznja { get; set; }
        public DbSet<Ugovor> Ugovor { get; set; }
        public DbSet<OcjenaDobavljaca> OcjenaDobavljaca { get; set; }
        public DbSet<Certifikat> Certifikat { get; set; }
        public DbSet<ZahtjevZaPromjenom> ZahtjevZaPromjenom { get; set; }
    }
}