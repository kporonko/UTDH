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
    public class InterfaceCameraConfiguration
            : IEntityTypeConfiguration<InterfaceCamera>
    {
        void IEntityTypeConfiguration<InterfaceCamera>.Configure(EntityTypeBuilder<InterfaceCamera> builder)
        {
            builder
                .ToTable(nameof(InterfaceCamera))
                .HasKey(t => t.Id);
            builder
                .Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder
                .Property(t => t.InterfaceId)
                .IsRequired()
                .HasColumnName("InterfaceId")
                .HasColumnType("int");
            builder
                .Property(t => t.CameraId)
                .IsRequired()
                .HasColumnName("CameraId")
                .HasColumnType("int");
        }
    }
}
