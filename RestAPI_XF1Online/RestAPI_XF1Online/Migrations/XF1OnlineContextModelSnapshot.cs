﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestAPI_XF1Online.Data;

#nullable disable

namespace RestAPI_XF1Online.Migrations
{
    [DbContext(typeof(XF1OnlineContext))]
    partial class XF1OnlineContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DriverPlayerTeam", b =>
                {
                    b.Property<int>("DriversId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerTeamsId")
                        .HasColumnType("int");

                    b.HasKey("DriversId", "PlayerTeamsId");

                    b.HasIndex("PlayerTeamsId");

                    b.ToTable("DriverPlayerTeam");
                });

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

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

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

            modelBuilder.Entity("RestAPI_XF1Online.Models.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("RestAPI_XF1Online.Models.Player", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AgeRange")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ConfirmedAccount")
                        .HasColumnType("bit");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Username");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("RestAPI_XF1Online.Models.PlayerTeam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlayerUsername")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ScuderiaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlayerUsername");

                    b.HasIndex("ScuderiaId");

                    b.ToTable("PlayerTeams");
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

            modelBuilder.Entity("RestAPI_XF1Online.Models.Ranking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ChampionshipId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("PlayerTeamId")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChampionshipId");

                    b.HasIndex("PlayerTeamId");

                    b.ToTable("Rankings");
                });

            modelBuilder.Entity("RestAPI_XF1Online.Models.Scuderia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Scuderias");
                });

            modelBuilder.Entity("DriverPlayerTeam", b =>
                {
                    b.HasOne("RestAPI_XF1Online.Models.Driver", null)
                        .WithMany()
                        .HasForeignKey("DriversId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestAPI_XF1Online.Models.PlayerTeam", null)
                        .WithMany()
                        .HasForeignKey("PlayerTeamsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RestAPI_XF1Online.Models.PlayerTeam", b =>
                {
                    b.HasOne("RestAPI_XF1Online.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerUsername")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestAPI_XF1Online.Models.Scuderia", "Scuderia")
                        .WithMany()
                        .HasForeignKey("ScuderiaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");

                    b.Navigation("Scuderia");
                });

            modelBuilder.Entity("RestAPI_XF1Online.Models.Race", b =>
                {
                    b.HasOne("RestAPI_XF1Online.Models.Championship", null)
                        .WithMany("Races")
                        .HasForeignKey("ChampionshipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RestAPI_XF1Online.Models.Ranking", b =>
                {
                    b.HasOne("RestAPI_XF1Online.Models.Championship", "Championship")
                        .WithMany()
                        .HasForeignKey("ChampionshipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestAPI_XF1Online.Models.PlayerTeam", "PlayerTeam")
                        .WithMany()
                        .HasForeignKey("PlayerTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Championship");

                    b.Navigation("PlayerTeam");
                });

            modelBuilder.Entity("RestAPI_XF1Online.Models.Championship", b =>
                {
                    b.Navigation("Races");
                });
#pragma warning restore 612, 618
        }
    }
}
