using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Configuration
{
    public class SystemConfiguration
            : IEntityTypeConfiguration<Models.System>
    {
        void IEntityTypeConfiguration<Models.System>.Configure(EntityTypeBuilder<Models.System> builder)
        {
            builder
                .ToTable(nameof(Models.System))
                .HasKey(t => t.Id);
            builder
                .Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder
                .Property(t => t.SystemName)
                .HasColumnName("SystemName")
                .HasColumnType("varchar(MAX)");
        }
    }
}
