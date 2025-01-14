﻿// <auto-generated />
using GTS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;

#nullable disable

namespace GTS.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GTS.Domain.GTS.DataPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long>("Elevation")
                        .HasColumnType("bigint");

                    b.Property<int>("GeoTimeSeriesId")
                        .HasColumnType("int");

                    b.Property<Point>("Point")
                        .IsRequired()
                        .HasColumnType("geography");

                    b.Property<long>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bigint");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GeoTimeSeriesId");

                    b.HasIndex("TimeStamp");

                    b.ToTable("DataPoints", (string)null);
                });

            modelBuilder.Entity("GTS.Domain.GTS.GeoTimeSeries", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClassName");

                    b.ToTable("GeoTimeSeries", (string)null);
                });

            modelBuilder.Entity("GTS.Domain.GTS.DataPoint", b =>
                {
                    b.HasOne("GTS.Domain.GTS.GeoTimeSeries", "GeoTimeSeries")
                        .WithMany("Points")
                        .HasForeignKey("GeoTimeSeriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GeoTimeSeries");
                });

            modelBuilder.Entity("GTS.Domain.GTS.GeoTimeSeries", b =>
                {
                    b.Navigation("Points");
                });
#pragma warning restore 612, 618
        }
    }
}
