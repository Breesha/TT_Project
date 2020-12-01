using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TT_Project_Model
{
    public partial class TT_ProjectContext : DbContext
    {
        public TT_ProjectContext()
        {
        }

        public TT_ProjectContext(DbContextOptions<TT_ProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bike> Bikes { get; set; }
        public virtual DbSet<Race> Races { get; set; }
        public virtual DbSet<Rider> Riders { get; set; }
        public virtual DbSet<RiderAccount> RiderAccounts { get; set; }
        public virtual DbSet<StaffAccount> StaffAccounts { get; set; }
        public virtual DbSet<staff> staff { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TT_Project;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bike>(entity =>
            {
                entity.Property(e => e.BikeId).HasColumnName("BikeID");

                entity.Property(e => e.BikeMake)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.BikeSponsor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RiderId).HasColumnName("RiderID");

                entity.HasOne(d => d.Rider)
                    .WithMany(p => p.Bikes)
                    .HasForeignKey(d => d.RiderId)
                    .HasConstraintName("FK__Bikes__RiderID__2DE6D218");
            });

            modelBuilder.Entity<Race>(entity =>
            {
                entity.Property(e => e.RaceId).HasColumnName("RaceID");

                entity.Property(e => e.RaceName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rider>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Experience)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nationality)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RaceId).HasColumnName("RaceID");

                entity.Property(e => e.RiderId).HasColumnName("RiderID");

                entity.HasOne(d => d.Race)
                    .WithMany()
                    .HasForeignKey(d => d.RaceId)
                    .HasConstraintName("FK__Riders__RaceID__2B0A656D");

                entity.HasOne(d => d.RiderNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.RiderId)
                    .HasConstraintName("FK__Riders__RiderID__2A164134");
            });

            modelBuilder.Entity<RiderAccount>(entity =>
            {
                entity.HasKey(e => e.RiderId)
                    .HasName("PK__RiderAcc__7D726C0008AEE44F");

                entity.Property(e => e.RiderId).HasColumnName("RiderID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Passwrd)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StaffAccount>(entity =>
            {
                entity.HasKey(e => e.StaffId)
                    .HasName("PK__StaffAcc__96D4AAF7B912F10A");

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Passwrd)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<staff>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Staff");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.HasOne(d => d.Staff)
                    .WithMany()
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK__Staff__StaffID__31B762FC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
