// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Phlosales.API.DbContexts;

#nullable disable

namespace Phlosales.API.Migrations
{
    [DbContext(typeof(PhloSysDbContext))]
    [Migration("20220412230302_InitWithGuid")]
    partial class InitWithGuid
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Phlosales.API.Entities.ProdOrder", b =>
                {
                    b.Property<Guid>("ProdOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ProdOrderId");

                    b.ToTable("ProdOrders");

                    b.HasData(
                        new
                        {
                            ProdOrderId = new Guid("518de724-fcb4-468b-86d2-774f7b899eeb"),
                            CustomerName = "Chris",
                            Price = 20.0,
                            ProductName = "laptop"
                        },
                        new
                        {
                            ProdOrderId = new Guid("6f45ee91-4c47-4ace-8146-22c5fd564328"),
                            CustomerName = "John",
                            Price = 20.0,
                            ProductName = "phone"
                        },
                        new
                        {
                            ProdOrderId = new Guid("48534156-4923-45c3-9e3d-46736be70ce4"),
                            CustomerName = "Raph",
                            Price = 25.0,
                            ProductName = "airpod"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
