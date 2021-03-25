using DevRupt.Core.Models;
using Microsoft.EntityFrameworkCore;


namespace DevRupt.App.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Reservation>()
                .HasOne(r => r.RatePlan);

            builder.Entity<Reservation>()
                .HasOne(r => r.PrimaryGuest);

            builder.Entity<RatePlan>()
                .HasMany(r => r.Reservations)
                .WithOne(r => r.RatePlan);

            builder.Entity<Folio>().HasKey(f => new {f.Id, f.ReservationId });
            
            builder.Entity<Folio>().Ignore(f => f.RelatedFolios);

            builder.Entity<Folio>().HasOne(f => f.Reservation);
        }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<PrimaryGuest> PrimaryGuests { get; set; }

        public DbSet<RatePlan> RatePlans { get; set; }

        public DbSet<ServiceItem> ServiceItems { get; set; }

        public DbSet<Folio> Folios { get; set; }

        public DbSet<Charge> Charges { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<ServiceTotalAmount> ServiceTotalAmounts { get; set; }

        public DbSet<ServiceDate> ServiceDates { get; set; }


    }
}
