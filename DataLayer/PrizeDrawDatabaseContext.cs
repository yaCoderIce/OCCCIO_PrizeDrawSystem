using PrizeDraw.DataLayer.Model.Identity;
using PrizeDraw.DataLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace PrizeDraw.DataLayer
{
    /// <summary>
    /// Manage the pipe to the database
    /// </summary>
    public class PrizeDrawDatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Vendor> Vendors { get; set; }

        public DbSet<Prize> Prizes { get; set; }

        public DbSet<Scan> Scans { get; set; }

        public DbSet<Winner> Winners { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<Attendee> Attendees { get; set; }

        private string ConnectionString { get; set; }

        public PrizeDrawDatabaseContext(DbContextOptions<PrizeDrawDatabaseContext> options)
            : base(options)
        {
        }

        public PrizeDrawDatabaseContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public PrizeDrawDatabaseContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Depending on how the context was constructed it may not not configured yet.
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Role>()
                .HasKey(r => r.Id);

            // Explictly define composite keys. Entity is smart but not composite key smart.
            modelBuilder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.RoleId });
            modelBuilder.Entity<Scan>().HasKey(s => new { s.AttendeeId, s.VendorId });
            modelBuilder.Entity<Winner>().HasKey(w => new { w.AttendeeId, w.PrizeId });

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(k => k.RoleId)
                .IsRequired();

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(k => k.UserId)
                .IsRequired();

            modelBuilder.Entity<Vendor>()
                .HasMany(u => u.Users)
                .WithOne(v => v.Vendor)
                .HasForeignKey(k => k.VendorId);

            modelBuilder.Entity<Prize>()
                .HasOne(p => p.Sponsor)
                .WithMany(v => v.Prizes)
                .HasForeignKey(k => k.VendorId);

            modelBuilder.Entity<Winner>()
                .HasOne(p => p.Prize)
                .WithMany(p => p.Winners)
                .HasForeignKey(k => k.PrizeId);

            modelBuilder.Entity<Scan>()
                .HasOne(v => v.Vendor)
                .WithMany(v => v.Scans)
                .HasForeignKey(k => k.VendorId);

            modelBuilder.Entity<Scan>()
                .HasOne(a => a.Attendee)
                .WithMany(a => a.Scans)
                .HasForeignKey(k => k.AttendeeId);
        }
    }
}
