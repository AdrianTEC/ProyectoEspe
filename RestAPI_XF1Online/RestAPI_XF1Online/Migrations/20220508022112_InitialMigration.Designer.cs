﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestAPI_XF1Online.Data;

#nullable disable

namespace RestAPI_XF1Online.Migrations
{
    [DbContext(typeof(XF1OnlineContext))]
    [Migration("20220508022112_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RestAPI_XF1Online.Models.Championship", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("FinishingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FinishingTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("StartingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartingTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Championships");
                });

            modelBuilder.Entity("RestAPI_XF1Online.Models.Race", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ActualState")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChampionshipId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FinishingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FinishingTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("StartingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartingTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("TrackName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("ChampionshipId");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("RestAPI_XF1Online.Models.Race", b =>
                {
                    b.HasOne("RestAPI_XF1Online.Models.Championship", null)
                        .WithMany("Races")
                        .HasForeignKey("ChampionshipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RestAPI_XF1Online.Models.Championship", b =>
                {
                    b.Navigation("Races");
                });
#pragma warning restore 612, 618
        }
    }
}
