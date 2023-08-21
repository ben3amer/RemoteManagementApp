using HRBackend.AppCore.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRBackend.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Contrat> Contrats { get; set; }
        public DbSet<Demande> Demandes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the relationship between Demande and User
            modelBuilder.Entity<Demande>()
                .HasOne(d => d.Employe)
                .WithMany(u => u.Demandes)
                .HasForeignKey(d => d.IdEmployee);

            // Configure the relationship between User and Contrat
            modelBuilder.Entity<User>()
                .HasOne(u => u.Contrat)
                .WithMany()
                .HasForeignKey(u => u.IdContrat);

            // Define primary keys
            modelBuilder.Entity<Contrat>()
                .HasKey(c => c.IdContrat);

            modelBuilder.Entity<User>().HasKey(u => u.Id);

            modelBuilder.Entity<User>().Property(u => u.PasswordSalt)
                .HasColumnType("bytea"); 

            modelBuilder.Entity<User>().Property(u => u.HashedPassword)
                .HasColumnType("bytea");

            modelBuilder.Entity<Demande>()
                .HasKey(d => d.IdDemande);

            // Other entity configurations

            base.OnModelCreating(modelBuilder);
        }
    }

}
