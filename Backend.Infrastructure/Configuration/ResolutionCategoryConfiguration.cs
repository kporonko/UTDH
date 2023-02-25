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
    public class ResolutionCategoryConfiguration
            : IEntityTypeConfiguration<ResolutionCategory>
    {
        void IEntityTypeConfiguration<ResolutionCategory>.Configure(EntityTypeBuilder<ResolutionCategory> builder)
        {
            builder
                .ToTable(nameof(ResolutionCategory))
                .HasKey(t => t.Id);
            builder
                .Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder
                .Property(t => t.Resolution)
                .HasColumnName("Resolution")
                .HasColumnType("varchar(MAX)");
            builder
                .Property(t => t.ResolutionName)
                .HasColumnName("ResolutionName")
                .HasColumnType("varchar(MAX)");
        }
    }
}
