﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PISI.Infrastructure.Context;

#nullable disable

namespace PISI.Infrastructure.Migrations
{
    [DbContext(typeof(PISIDbContext))]
    [Migration("20240202175546_AddDataToTable")]
    partial class AddDataToTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PISI.Domain.Entities.Service.ServiceUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTimeOffset?>("DateUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ServiceId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Token")
                        .HasColumnType("longtext");

                    b.Property<double?>("TokenExpiry")
                        .HasColumnType("double");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ServiceUser");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedBy = "ID-2345",
                            DateCreated = new DateTime(2024, 2, 2, 18, 55, 46, 505, DateTimeKind.Local).AddTicks(82),
                            Password = "W@ke123",
                            ServiceId = "ID-2345"
                        });
                });

            modelBuilder.Entity("PISI.Domain.Entities.Subscription.Subscribe", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTimeOffset?>("DateUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsSubcribed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ServiceId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Subscribe");
                });
#pragma warning restore 612, 618
        }
    }
}
