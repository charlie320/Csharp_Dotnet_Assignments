﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using WeddingPlanner.Models;

namespace WeddingPlanner.Migrations
{
    [DbContext(typeof(WeddingPlannerContext))]
    [Migration("20180208220435_TestConfigString")]
    partial class TestConfigString
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("WeddingPlanner.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("Test");

                    b.Property<DateTime>("created_at");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WeddingPlanner.Models.Wedding", b =>
                {
                    b.Property<int>("WeddingId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<int>("PlannerId");

                    b.Property<string>("WedderOne")
                        .IsRequired();

                    b.Property<string>("WedderTwo")
                        .IsRequired();

                    b.Property<string>("WeddingAddress")
                        .IsRequired();

                    b.Property<DateTime>("created_at");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("WeddingId");

                    b.HasIndex("PlannerId");

                    b.ToTable("Weddings");
                });

            modelBuilder.Entity("WeddingPlanner.Models.WeddingConfirmation", b =>
                {
                    b.Property<int>("ConfirmationId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GuestId");

                    b.Property<int>("WeddingId");

                    b.HasKey("ConfirmationId");

                    b.HasIndex("GuestId");

                    b.HasIndex("WeddingId");

                    b.ToTable("WeddingConfirmations");
                });

            modelBuilder.Entity("WeddingPlanner.Models.Wedding", b =>
                {
                    b.HasOne("WeddingPlanner.Models.User", "Planner")
                        .WithMany("WeddingsPlanned")
                        .HasForeignKey("PlannerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WeddingPlanner.Models.WeddingConfirmation", b =>
                {
                    b.HasOne("WeddingPlanner.Models.User", "Guest")
                        .WithMany("WeddingsAttending")
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WeddingPlanner.Models.Wedding", "Wedding")
                        .WithMany("GuestsAttending")
                        .HasForeignKey("WeddingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}