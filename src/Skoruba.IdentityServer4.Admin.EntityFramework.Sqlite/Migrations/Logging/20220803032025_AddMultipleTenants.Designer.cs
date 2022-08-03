﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Skoruba.IdentityServer4.Admin.EntityFramework.Shared.DbContexts;

namespace Skoruba.IdentityServer4.Admin.EntityFramework.Sqlite.Migrations.Logging
{
    [DbContext(typeof(AdminLogDbContext))]
    [Migration("20220803032025_AddMultipleTenants")]
    partial class AddMultipleTenants
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("Skoruba.IdentityServer4.Admin.EntityFramework.Entities.Log", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Exception")
                        .HasColumnType("TEXT");

                    b.Property<string>("Level")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("LogEvent")
                        .HasColumnType("TEXT");

                    b.Property<string>("Message")
                        .HasColumnType("TEXT");

                    b.Property<string>("MessageTemplate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Properties")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("TimeStamp")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Log");
                });
#pragma warning restore 612, 618
        }
    }
}
