using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Infrastructure.Models;

namespace Backend.Infrastructure.Configuration
{
    public class CameraSystemConfiguration
            : IEntityTypeConfiguration<CameraSystem>
    {
        void IEntityTypeConfiguration<CameraSystem>.Configure(EntityTypeBuilder<CameraSystem> builder)
        {
            builder
                .ToTable(nameof(CameraSystem))
                .HasKey(t => t.Id);
            builder
                .Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder
                .Property(t => t.SystemId)
                .IsRequired()
                .HasColumnName("SystemId")
                .HasColumnType("int");
            builder
                .Property(t => t.CameraId)
                .IsRequired()
                .HasColumnName("CameraId")
                .HasColumnType("int");
        }
    }
}
