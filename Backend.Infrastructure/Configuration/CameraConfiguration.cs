using Backend.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Configuration
{
    public class CameraConfiguration : IEntityTypeConfiguration<Camera>
    {
        public void Configure(EntityTypeBuilder<Camera> builder)
        {
            builder
                .ToTable(nameof(Camera))
                .HasKey(t => t.Id);

            builder
                .Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder
                .Property(t => t.Photo)
                .IsRequired()
                .HasColumnName("Photo")
                .HasColumnType("varchar(max)");
            
            builder
                .Property(t => t.Price)
                .IsRequired()
                .HasColumnName("Price")
                .HasColumnType("decimal(18,2)");
            builder
                .Property(t => t.InStockCount)
                .HasColumnName("InStockCount")
                .HasColumnType("int");
            builder
                .Property(t => t.SensorWidth)
                .HasColumnName("SensorWidth")
                .HasColumnType("float");
            builder
                .Property(t => t.SensorHeight)
                .HasColumnName("SensorHeight")
                .HasColumnType("float");
            builder
                .Property(t => t.IsOpticInComplect)
                .HasColumnName("IsOpticInComplect")
                .HasColumnType("bit");
            builder
                .Property(t => t.MegaPixels)
                .HasColumnName("MegaPixels")
                .HasColumnType("float");
            builder
                .Property(t => t.LCDMount)
                .HasColumnName("LCDMount")
                .HasColumnType("varchar(max)");
            builder
                .Property(t => t.Microphone)
                .HasColumnName("Microphone")
                .HasColumnType("varchar(max)");
            builder
                .Property(t => t.Protection)
                .HasColumnName("Protection")
                .HasColumnType("varchar(max)");
            builder
                .Property(t => t.Supply)
                .HasColumnName("Supply")
                .HasColumnType("varchar(max)");
            builder
                .Property(t => t.IsMacroPhotography)
                .HasColumnName("IsMacroPhotography")
                .HasColumnType("bit");
            builder
                .Property(t => t.Stabilization)
                .HasColumnName("Stabilization")
                .HasColumnType("varchar(max)");
            builder
                .Property(t => t.IsRAWSupport)
                .HasColumnName("IsRAWSupport")
                .HasColumnType("bit");
            builder
                .Property(t => t.SoundFormat)
                .HasColumnName("SoundFormat")
                .HasColumnType("varchar(max)");
            builder
                .Property(t => t.IsSensorDisplay)
                .HasColumnName("IsSensorDisplay")
                .HasColumnType("bit");
            builder
                .Property(t => t.ExpositionMode)
                .HasColumnName("ExpositionMode")
                .HasColumnType("varchar(max)");
            builder
                .Property(t => t.LCDDiagonal)
                .HasColumnName("LCDDiagonal")
                .HasColumnType("varchar(max)");
            builder
                .Property(t => t.MaxZoomValue)
                .HasColumnName("MaxZoomValue")
                .HasColumnType("int");
        }
    }
}