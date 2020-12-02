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
        public virtual DbSet<Entry> Entries { get; set; }
        public virtual DbSet<Race> Races { get; set; }
        public virtual DbSet<RiderAccount> RiderAccounts { get; set; }
        public virtual DbSet<StaffAccount> StaffAccounts { get; set; }

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
                    .HasConstraintName("FK__Bikes__RiderID__382F5661");
            });

            modelBuilder.Entity<Entry>(entity =>
            {
                entity.Property(e => e.EntryId).HasColumnName("EntryID");

                entity.Property(e => e.RaceId).HasColumnName("RaceID");

                entity.Property(e => e.RiderId).HasColumnName("RiderID");

                entity.HasOne(d => d.Race)
                    .WithMany(p => p.Entries)
                    .HasForeignKey(d => d.RaceId)
                    .HasConstraintName("FK__Entries__RaceID__3552E9B6");

                entity.HasOne(d => d.Rider)
                    .WithMany(p => p.Entries)
                    .HasForeignKey(d => d.RiderId)
                    .HasConstraintName("FK__Entries__RiderID__345EC57D");
            });

            modelBuilder.Entity<Race>(entity =>
            {
                entity.Property(e => e.RaceId).HasColumnName("RaceID");

                entity.Property(e => e.RaceName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RiderAccount>(entity =>
            {
                entity.HasKey(e => e.RiderId)
                    .HasName("PK__RiderAcc__7D726C001236FE32");

                entity.Property(e => e.RiderId).HasColumnName("RiderID");

                entity.Property(e => e.DateOfBirth)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

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

                entity.Property(e => e.Passwrd)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StaffAccount>(entity =>
            {
                entity.HasKey(e => e.StaffId)
                    .HasName("PK__StaffAcc__96D4AAF7469AD893");

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Passwrd)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
