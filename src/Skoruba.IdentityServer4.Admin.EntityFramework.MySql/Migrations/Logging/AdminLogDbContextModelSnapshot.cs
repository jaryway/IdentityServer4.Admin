﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Skoruba.IdentityServer4.Admin.EntityFramework.Shared.DbContexts;

namespace Skoruba.IdentityServer4.Admin.EntityFramework.MySql.Migrations.Logging
{
    [DbContext(typeof(AdminLogDbContext))]
    partial class AdminLogDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("Skoruba.IdentityServer4.Admin.EntityFramework.Entities.Log", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Exception")
                        .HasColumnType("longtext");

                    b.Property<string>("Level")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("LogEvent")
                        .HasColumnType("longtext");

                    b.Property<string>("Message")
                        .HasColumnType("longtext");

                    b.Property<string>("MessageTemplate")
                        .HasColumnType("longtext");

                    b.Property<string>("Properties")
                        .HasColumnType("longtext");

                    b.Property<DateTimeOffset>("TimeStamp")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Log");
                });
#pragma warning restore 612, 618
        }
    }
}
