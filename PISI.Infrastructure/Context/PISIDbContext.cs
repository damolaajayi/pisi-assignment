using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using PISI.Domain.Entities.Service;
using PISI.Domain.Entities.Subscription;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace PISI.Infrastructure.Context
{
    public class PISIDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;
        public PISIDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public virtual DbSet<ServiceUser> ServiceUser { get; set; }
        public virtual DbSet<Subscribe> Subscribe { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder? optionsBuilder)
        {
            if (optionsBuilder != null && !optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseMySQL(_configuration.GetConnectionString("DbConfig")); ;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ServiceUser>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Subscribe>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entity.ClrType.GetProperties()
                    .Where(p => p.PropertyType == typeof(decimal));
                var dateandtimepropertise = entity.ClrType.GetProperties()
                    .Where(t => t.PropertyType == typeof(DateTimeOffset));
                foreach (var property in properties)
                {
                    modelBuilder.Entity(entity.Name).Property(property.Name)
                        .HasConversion<double>();
                }
                foreach (var property in dateandtimepropertise)
                {
                    modelBuilder.Entity(entity.Name).Property(property.Name)
                        .HasConversion(new DateTimeOffsetToBinaryConverter());
                }
            }
        }
    }
}
