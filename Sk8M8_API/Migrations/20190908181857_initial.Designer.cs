﻿// <auto-generated />
using System;
using GeoAPI.Geometries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Sk8M8_API.Models;

namespace Sk8M8_API.Migrations
{
    [DbContext(typeof(SkateContext))]
    [Migration("20190908181857_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Sk8M8_API.Models.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Sk8M8_API.Models.Client", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("Email");

                    b.Property<string>("Geolocation");

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Sk8M8_API.Models.ClientLogin", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("ClientId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("IPAddress");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("ClientLogin");
                });

            modelBuilder.Entity("Sk8M8_API.Models.LocationCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("CategoryId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<long?>("MapMarkerId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("MapMarkerId");

                    b.ToTable("LocationCategory");
                });

            modelBuilder.Entity("Sk8M8_API.Models.MapMarker", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("CreatorId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("LocationCategory");

                    b.Property<string>("Name");

                    b.Property<IPoint>("Point");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("MapMarker");
                });

            modelBuilder.Entity("Sk8M8_API.Models.Media", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("ClientId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("Filename");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Media");
                });

            modelBuilder.Entity("Sk8M8_API.Models.MediaRating", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("ClientId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<long?>("MediaId");

                    b.Property<int>("Rating");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("MediaId");

                    b.ToTable("MediaRating");
                });

            modelBuilder.Entity("Sk8M8_API.Models.Permission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Permission");
                });

            modelBuilder.Entity("Sk8M8_API.Models.UserPermission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("ClientId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<long?>("PermissionId");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("PermissionId");

                    b.ToTable("UserPermission");
                });

            modelBuilder.Entity("Sk8M8_API.Models.ClientLogin", b =>
                {
                    b.HasOne("Sk8M8_API.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");
                });

            modelBuilder.Entity("Sk8M8_API.Models.LocationCategory", b =>
                {
                    b.HasOne("Sk8M8_API.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("Sk8M8_API.Models.MapMarker", "MapMarker")
                        .WithMany()
                        .HasForeignKey("MapMarkerId");
                });

            modelBuilder.Entity("Sk8M8_API.Models.MapMarker", b =>
                {
                    b.HasOne("Sk8M8_API.Models.Client", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");
                });

            modelBuilder.Entity("Sk8M8_API.Models.Media", b =>
                {
                    b.HasOne("Sk8M8_API.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");
                });

            modelBuilder.Entity("Sk8M8_API.Models.MediaRating", b =>
                {
                    b.HasOne("Sk8M8_API.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.HasOne("Sk8M8_API.Models.Media", "Media")
                        .WithMany()
                        .HasForeignKey("MediaId");
                });

            modelBuilder.Entity("Sk8M8_API.Models.UserPermission", b =>
                {
                    b.HasOne("Sk8M8_API.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.HasOne("Sk8M8_API.Models.Permission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId");
                });
#pragma warning restore 612, 618
        }
    }
}
