﻿using Backend.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .ToTable(nameof(Order))
                .HasKey(t => t.Id);
            builder
                .Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder
                .Property(t => t.CustomerName)
                .IsRequired()
                .HasColumnName("CustomerName")
                .HasColumnType("nvarchar(max)");
            builder
                .Property(t => t.CustomerSurname)
                .IsRequired()
                .HasColumnName("CustomerSurname")
                .HasColumnType("nvarchar(max)");
            builder
                .Property(t => t.CustomerPatronymic)
                .IsRequired()
                .HasColumnName("CustomerPatronymic")
                .HasColumnType("nvarchar(max)");
            builder
                .Property(t => t.CustomerPhone)
                .IsRequired()
                .HasColumnName("CustomerPhone")
                .HasColumnType("nvarchar(max)");
            builder
                .Property(t => t.CustomerEmail)
                .IsRequired()
                .HasColumnName("CustomerEmail")
                .HasColumnType("nvarchar(max)");
            builder
                .Property(t => t.CustomerAddress)
                .IsRequired()
                .HasColumnName("CustomerAddress")
                .HasColumnType("nvarchar(max)");
            builder
                .Property(t => t.CustomerPostOffice)
                .IsRequired()
                .HasColumnName("CustomerPostOffice")
                .HasColumnType("nvarchar(max)");
        }
    }
}
