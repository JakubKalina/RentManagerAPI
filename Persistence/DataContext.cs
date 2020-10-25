using Domain.Models;
using Domain.Models.Entities;
using Domain.Models.Entities.Association;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<MaintenanceMessage> MaintenanceMessages { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Flat> Flats { get; set; }
        public DbSet<FlatInformation> FlatInformations { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Tenancy> Tenancies { get; set; }
        public DbSet<FlatLandlord> FlatLandlords { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                .HasKey(x => x.Id);

            // Dla wiadomości i użytkowników
            builder.Entity<Message>()
                .HasOne(m => m.UserFrom).WithMany(u => u.SentMessages).HasForeignKey(m => m.UserFromId);

            builder.Entity<Message>()
                .HasOne(m => m.UserTo).WithMany(u => u.ReceivedMessages).HasForeignKey(m => m.UserToId);

            // Dla opinii i użytkowników
            builder.Entity<Review>()
                .HasOne(m => m.UserFrom).WithMany(u => u.SentReviews).HasForeignKey(m => m.UserFromId);

            builder.Entity<Review>()
                .HasOne(m => m.UserTo).WithMany(u => u.ReceivedReviews).HasForeignKey(m => m.UserToId);


            ConfigureCompositeKeys(builder);
            ConfigureCascadeProperties(builder);
            ConfigureEnums(builder);
        }

        private static void ConfigureEnums(ModelBuilder builder)
        {
        }

        private static void ConfigureCompositeKeys(ModelBuilder builder)
        {
            builder.Entity<FlatLandlord>()
                .HasKey(o => new { o.FlatId, o.UserId });
        }

        private static void ConfigureCascadeProperties(ModelBuilder builder)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}