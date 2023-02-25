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
    public class ModelConfiguration
        : IEntityTypeConfiguration<Model>
    {
        void IEntityTypeConfiguration<Model>.Configure(EntityTypeBuilder<Model> builder)
        {
            builder
                .ToTable(nameof(Model))
                .HasKey(t => t.Id);
            builder
                .Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder
                .Property(t => t.Manufacturer)
                .HasColumnName("Manufacturer")
                .HasColumnType("varchar(MAX)");
            builder
                .Property(t => t.ModelName)
                .HasColumnName("ModelName")
                .HasColumnType("varchar(MAX)");
            builder
                .Property(t => t.Country)
                .HasColumnName("Country")
                .HasColumnType("varchar(MAX)");
        }
    }
}
