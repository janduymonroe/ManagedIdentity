﻿using ManagedIdentity.Model;
using Microsoft.EntityFrameworkCore;

namespace ManagedIdentity.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Wizzer> Wizzers { get; set; }

        public ApplicationContext(DbContextOptions opt) : base(opt)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Entity<Wizzer>(entity =>
            {
                entity.Property(p => p.Id).UseIdentityColumn();
            });
           
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Wizzer).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
