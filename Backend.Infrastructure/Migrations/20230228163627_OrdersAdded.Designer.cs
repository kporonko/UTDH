﻿// <auto-generated />
using Backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230228163627_OrdersAdded")]
    partial class OrdersAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Backend.Infrastructure.Models.Camera", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ExpositionMode")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasColumnName("ExpositionMode");

                    b.Property<int>("InStockCount")
                        .HasColumnType("int")
                        .HasColumnName("InStockCount");

                    b.Property<bool>("IsMacroPhotography")
                        .HasColumnType("bit")
                        .HasColumnName("IsMacroPhotography");

                    b.Property<bool>("IsOpticInComplect")
                        .HasColumnType("bit")
                        .HasColumnName("IsOpticInComplect");

                    b.Property<bool>("IsRAWSupport")
                        .HasColumnType("bit")
                        .HasColumnName("IsRAWSupport");

                    b.Property<bool>("IsSensorDisplay")
                        .HasColumnType("bit")
                        .HasColumnName("IsSensorDisplay");

                    b.Property<string>("LCDDiagonal")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasColumnName("LCDDiagonal");

                    b.Property<string>("LCDMount")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasColumnName("LCDMount");

                    b.Property<int>("MaxZoomValue")
                        .HasColumnType("int")
                        .HasColumnName("MaxZoomValue");

                    b.Property<double>("MegaPixels")
                        .HasColumnType("float")
                        .HasColumnName("MegaPixels");

                    b.Property<string>("Microphone")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Microphone");

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Photo");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Price");

                    b.Property<string>("Protection")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Protection");

                    b.Property<int>("ResolutionCategoryId")
                        .HasColumnType("int");

                    b.Property<double>("SensorHeight")
                        .HasColumnType("float")
                        .HasColumnName("SensorHeight");

                    b.Property<double>("SensorWidth")
                        .HasColumnType("float")
                        .HasColumnName("SensorWidth");

                    b.Property<string>("SoundFormat")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasColumnName("SoundFormat");

                    b.Property<string>("Stabilization")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Stabilization");

                    b.Property<string>("Supply")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Supply");

                    b.HasKey("Id");

                    b.HasIndex("ModelId")
                        .IsUnique();

                    b.HasIndex("ResolutionCategoryId");

                    b.ToTable("Camera", (string)null);
                });

            modelBuilder.Entity("Backend.Infrastructure.Models.CameraSystem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CameraId")
                        .HasColumnType("int")
                        .HasColumnName("CameraId");

                    b.Property<int>("SystemId")
                        .HasColumnType("int")
                        .HasColumnName("SystemId");

                    b.HasKey("Id");

                    b.HasIndex("CameraId");

                    b.HasIndex("SystemId");

                    b.ToTable("CameraSystem", (string)null);
                });

            modelBuilder.Entity("Backend.Infrastructure.Models.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int")
                        .HasColumnName("Amount");

                    b.Property<int>("CameraId")
                        .HasColumnType("int")
                        .HasColumnName("CameraId");

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("OrderId");

                    b.HasKey("Id");

                    b.HasIndex("CameraId");

                    b.HasIndex("OrderId");

                    b.ToTable("CartItem", (string)null);
                });

            modelBuilder.Entity("Backend.Infrastructure.Models.Interface", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("InterfaceName")
                        .IsRequired()
                        .HasColumnType("varchar(MAX)")
                        .HasColumnName("InterfaceName");

                    b.HasKey("Id");

                    b.ToTable("Interface", (string)null);
                });

            modelBuilder.Entity("Backend.Infrastructure.Models.InterfaceCamera", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CameraId")
                        .HasColumnType("int")
                        .HasColumnName("CameraId");

                    b.Property<int>("InterfaceId")
                        .HasColumnType("int")
                        .HasColumnName("InterfaceId");

                    b.HasKey("Id");

                    b.HasIndex("CameraId");

                    b.HasIndex("InterfaceId");

                    b.ToTable("InterfaceCamera", (string)null);
                });

            modelBuilder.Entity("Backend.Infrastructure.Models.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CameraId")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("varchar(MAX)")
                        .HasColumnName("Country");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("varchar(MAX)")
                        .HasColumnName("Manufacturer");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("varchar(MAX)")
                        .HasColumnName("ModelName");

                    b.HasKey("Id");

                    b.ToTable("Model", (string)null);
                });

            modelBuilder.Entity("Backend.Infrastructure.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CustomerAddress")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasColumnName("CustomerAddress");

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasColumnName("CustomerEmail");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasColumnName("CustomerName");

                    b.Property<string>("CustomerPatronymic")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasColumnName("CustomerPatronymic");

                    b.Property<string>("CustomerPhone")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasColumnName("CustomerPhone");

                    b.Property<string>("CustomerPostOffice")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasColumnName("CustomerPostOffice");

                    b.Property<string>("CustomerSurname")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasColumnName("CustomerSurname");

                    b.HasKey("Id");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("Backend.Infrastructure.Models.ResolutionCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Resolution")
                        .IsRequired()
                        .HasColumnType("varchar(MAX)")
                        .HasColumnName("Resolution");

                    b.Property<string>("ResolutionName")
                        .IsRequired()
                        .HasColumnType("varchar(MAX)")
                        .HasColumnName("ResolutionName");

                    b.HasKey("Id");

                    b.ToTable("ResolutionCategory", (string)null);
                });

            modelBuilder.Entity("Backend.Infrastructure.Models.System", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("SystemName")
                        .IsRequired()
                        .HasColumnType("varchar(MAX)")
                        .HasColumnName("SystemName");

                    b.HasKey("Id");

                    b.ToTable("System", (string)null);
                });

            modelBuilder.Entity("Backend.Infrastructure.Models.Camera", b =>
                {
                    b.HasOne("Backend.Infrastructure.Models.Model", "Model")
                        .WithOne("Camera")
                        .HasForeignKey("Backend.Infrastructure.Models.Camera", "ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Infrastructure.Models.ResolutionCategory", "ResolutionCategory")
                        .WithMany("Cameras")
                        .HasForeignKey("ResolutionCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Model");

                    b.Navigation("ResolutionCategory");
                });

            modelBuilder.Entity("Backend.Infrastructure.Models.CameraSystem", b =>
                {
                    b.HasOne("Backend.Infrastructure.Models.Camera", "Camera")
                        .WithMany("CameraSystems")
                        .HasForeignKey("CameraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Infrastructure.Models.System", "System")
                        .WithMany("CameraSystems")
                        .HasForeignKey("SystemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Camera");

                    b.Navigation("System");
                });

            modelBuilder.Entity("Backend.Infrastructure.Models.CartItem", b =>
                {
                    b.HasOne("Backend.Infrastructure.Models.Camera", "Camera")
                        .WithMany("CartItems")
                        .HasForeignKey("CameraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Infrastructure.Models.Order", "Order")
                        .WithMany("CartItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Camera");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Backend.Infrastructure.Models.InterfaceCamera", b =>
                {
                    b.HasOne("Backend.Infrastructure.Models.Camera", "Camera")
                        .WithMany("CameraInterfaces")
                        .HasForeignKey("CameraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Infrastructure.Models.Interface", "Interface")
                        .WithMany("InterfaceCameras")
                        .HasForeignKey("InterfaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Camera");

                    b.Navigation("Interface");
                });

            modelBuilder.Entity("Backend.Infrastructure.Models.Camera", b =>
                {
                    b.Navigation("CameraInterfaces");

                    b.Navigation("CameraSystems");

                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("Backend.Infrastructure.Models.Interface", b =>
                {
                    b.Navigation("InterfaceCameras");
                });

            modelBuilder.Entity("Backend.Infrastructure.Models.Model", b =>
                {
                    b.Navigation("Camera")
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Infrastructure.Models.Order", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("Backend.Infrastructure.Models.ResolutionCategory", b =>
                {
                    b.Navigation("Cameras");
                });

            modelBuilder.Entity("Backend.Infrastructure.Models.System", b =>
                {
                    b.Navigation("CameraSystems");
                });
#pragma warning restore 612, 618
        }
    }
}
