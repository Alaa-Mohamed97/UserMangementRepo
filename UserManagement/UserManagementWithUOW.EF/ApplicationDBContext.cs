using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagementWithUOW.Core.Models;

namespace UserManagementWithUOW.EF
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(a => a.Certifications)
                .WithMany(a => a.users)
                .UsingEntity<UsersCretifications>(
                a => a.HasOne(ac => ac.Certifications)
                .WithMany(b => b.UsersCretifications)
                .HasForeignKey(ac => ac.CertificationsId),

                a => a.HasOne(ac => ac.users)
                .WithMany(b => b.UsersCretifications)
                .HasForeignKey(ac => ac.UserId),
                a =>
                {
                    a.HasKey(t => new { t.UserId, t.CertificationsId });
                }
                );
        }
        public DbSet<User> users { get; set; }
        public DbSet<Certifications> Certifications { get; set; }
        public DbSet<UsersCretifications> UsersCretifications { get; set; }
    }
}
