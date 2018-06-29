﻿// <auto-generated />
using System;
using BabySitter.Core.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BabySitter.Web.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20180628053324_AddEndTimeToShift")]
    partial class AddEndTimeToShift
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("BabySitter.Core.Entities.Shift", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<LocalDateTime>("Bedtime");

                    b.Property<LocalDateTime?>("EndTime");

                    b.Property<int>("SitterId");

                    b.Property<LocalDateTime>("StartTime");

                    b.HasKey("Id");

                    b.HasIndex("SitterId");

                    b.ToTable("Shifts");
                });

            modelBuilder.Entity("BabySitter.Core.Entities.Sitter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("BabySitters");
                });

            modelBuilder.Entity("BabySitter.Core.Entities.Shift", b =>
                {
                    b.HasOne("BabySitter.Core.Entities.Sitter", "Sitter")
                        .WithMany("Shifts")
                        .HasForeignKey("SitterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("BabySitter.Core.Entities.HourlyRates", "HourlyRates", b1 =>
                        {
                            b1.Property<int>("ShiftId");

                            b1.Property<int>("AfterMidnight");

                            b1.Property<int>("BetweenBedtimeAndMidnight");

                            b1.Property<int>("Standard");

                            b1.ToTable("Shifts");

                            b1.HasOne("BabySitter.Core.Entities.Shift")
                                .WithOne("HourlyRates")
                                .HasForeignKey("BabySitter.Core.Entities.HourlyRates", "ShiftId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("BabySitter.Core.Entities.Sitter", b =>
                {
                    b.OwnsOne("BabySitter.Core.Entities.HourlyRates", "HourlyRates", b1 =>
                        {
                            b1.Property<int>("SitterId");

                            b1.Property<int>("AfterMidnight");

                            b1.Property<int>("BetweenBedtimeAndMidnight");

                            b1.Property<int>("Standard");

                            b1.ToTable("BabySitters");

                            b1.HasOne("BabySitter.Core.Entities.Sitter")
                                .WithOne("HourlyRates")
                                .HasForeignKey("BabySitter.Core.Entities.HourlyRates", "SitterId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
