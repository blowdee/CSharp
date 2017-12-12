using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CSC.Models
{
    public partial class CSCContext : DbContext
    {
        public CSCContext(DbContextOptions<CSCContext> options)
            : base(options) { }

        public virtual DbSet<Business> Business { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Family> Family { get; set; }
        public virtual DbSet<Offering> Offering { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<OrganizationCountry> OrganizationCountry { get; set; }
        public virtual DbSet<OrganizationTypes> OrganizationTypes { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-HP41GDT;Database=CSC;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Business>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.CountryNavigation)
                    .WithMany(p => p.Business)
                    .HasForeignKey(d => d.Country)
                    .HasConstraintName("FK_Business_Country");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.OfferingNavigation)
                    .WithMany(p => p.Department)
                    .HasForeignKey(d => d.Offering)
                    .HasConstraintName("FK_Department_Offering");
            });

            modelBuilder.Entity<Family>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.BusinessNavigation)
                    .WithMany(p => p.Family)
                    .HasForeignKey(d => d.Business)
                    .HasConstraintName("FK_Family_Business");
            });

            modelBuilder.Entity<Offering>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.FamilyNavigation)
                    .WithMany(p => p.Offering)
                    .HasForeignKey(d => d.Family)
                    .HasConstraintName("FK_Offering_Family");
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.Organization)
                    .HasForeignKey(d => d.Type)
                    .HasConstraintName("FK_Organization_OrganizationTypes1");
            });

            modelBuilder.Entity<OrganizationCountry>(entity =>
            {
                entity.HasKey(e => new { e.OrganizationId, e.CountryId })
                    .HasName("PK_Organization_Country");

                entity.ToTable("Organization_Country");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Organizations)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Organization_Country_Country");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Organization_Country_Organization");
            });

            modelBuilder.Entity<OrganizationTypes>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Surname).HasMaxLength(50);
            });
        }
    }
}