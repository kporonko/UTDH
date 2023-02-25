using Backend.Infrastructure.Configuration;
using Backend.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            
        }

        public DbSet<Camera> Cameras { get; set; }
        public DbSet<CameraSystem> CameraSystems { get; set; }
        public DbSet<Interface> Interfaces { get; set; }
        public DbSet<InterfaceCamera> InterfaceCameras { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Backend.Infrastructure.Models.System> Systems { get; set; }
        public DbSet<ResolutionCategory> ResolutionCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CameraConfiguration());
            modelBuilder.ApplyConfiguration(new CameraSystemConfiguration());
            modelBuilder.ApplyConfiguration(new InterfaceCameraConfiguration());
            modelBuilder.ApplyConfiguration(new InterfaceConfiguration());
            modelBuilder.ApplyConfiguration(new ModelConfiguration());
            modelBuilder.ApplyConfiguration(new ResolutionCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new SystemConfiguration());

            modelBuilder.Entity<CameraSystem>()
                .HasOne(cs => cs.Camera)
                .WithMany(c => c.CameraSystems)
                .HasForeignKey(cs => cs.CameraId);

            modelBuilder.Entity<CameraSystem>()
                .HasOne(cs => cs.System)
                .WithMany(s => s.CameraSystems)
                .HasForeignKey(cs => cs.SystemId);

            modelBuilder.Entity<InterfaceCamera>()
                .HasOne(ic => ic.Camera)
                .WithMany(c => c.CameraInterfaces)
                .HasForeignKey(ic => ic.CameraId);
            modelBuilder.Entity<InterfaceCamera>()
                .HasOne(ic => ic.Interface)
                .WithMany(i => i.InterfaceCameras)
                .HasForeignKey(ic => ic.InterfaceId);

            modelBuilder.Entity<Camera>()
                .HasOne(c => c.Model)
                .WithOne(m => m.Camera)
                .HasForeignKey<Camera>(c => c.ModelId);
            
            modelBuilder.Entity<Camera>()
                .HasOne(c => c.ResolutionCategory)
                .WithMany(rc => rc.Cameras)
                .HasForeignKey(c => c.ResolutionCategoryId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Default"));
        }
    }
}
