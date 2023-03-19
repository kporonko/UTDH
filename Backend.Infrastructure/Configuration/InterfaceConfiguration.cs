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
    public class InterfaceConfiguration
            : IEntityTypeConfiguration<Interface>
    {
        void IEntityTypeConfiguration<Interface>.Configure(EntityTypeBuilder<Interface> builder)
        {
            builder
                .ToTable(nameof(Interface))
                .HasKey(t => t.Id);
            builder
                .Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder
                .Property(t => t.InterfaceName)
                .HasColumnName("InterfaceName")
                .HasColumnType("nvarchar(MAX)");
        }
    }
}
