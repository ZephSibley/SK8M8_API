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
    [Migration("20191231175953_locationcategories")]
    partial class locationcategories
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Sk8M8_API.Models.Client", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Avatar");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("Email");

                    b.Property<IPoint>("Geolocation");

                    b.Property<string>("Password");

                    b.Property<string>("Status");

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

            modelBuilder.Entity("Sk8M8_API.Models.LocationType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("LocationType");
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

                    b.Property<long?>("VideoId");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("VideoId");

                    b.ToTable("MapMarker");
                });

            modelBuilder.Entity("Sk8M8_API.Models.MarkerCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<long?>("LocationTypeId");

                    b.Property<long?>("MapMarkerId");

                    b.HasKey("Id");

                    b.HasIndex("LocationTypeId");

                    b.HasIndex("MapMarkerId");

                    b.ToTable("MarkerCategory");
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

            modelBuilder.Entity("Sk8M8_API.Models.MapMarker", b =>
                {
                    b.HasOne("Sk8M8_API.Models.Client", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("Sk8M8_API.Models.Media", "Video")
                        .WithMany()
                        .HasForeignKey("VideoId");
                });

            modelBuilder.Entity("Sk8M8_API.Models.MarkerCategory", b =>
                {
                    b.HasOne("Sk8M8_API.Models.LocationType", "LocationType")
                        .WithMany()
                        .HasForeignKey("LocationTypeId");

                    b.HasOne("Sk8M8_API.Models.MapMarker", "MapMarker")
                        .WithMany()
                        .HasForeignKey("MapMarkerId");
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
