﻿// <auto-generated />
using System;
using ElectricityDataProvider.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ElectricityDataProvider.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221028154727_addedAggregatedElData")]
    partial class addedAggregatedElData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ElectricityDataProvider.DataAccess.Entities.AggregatedElData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double?>("PMinus")
                        .HasColumnType("float");

                    b.Property<double?>("PPlus")
                        .HasColumnType("float");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AggregatedElDatas");
                });
#pragma warning restore 612, 618
        }
    }
}
