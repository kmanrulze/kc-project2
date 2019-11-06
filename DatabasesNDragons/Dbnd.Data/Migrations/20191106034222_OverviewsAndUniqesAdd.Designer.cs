﻿// <auto-generated />
using System;
using Dbnd.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Dbnd.Data.Migrations
{
    [DbContext(typeof(DbndContext))]
    [Migration("20191106034222_OverviewsAndUniqesAdd")]
    partial class OverviewsAndUniqesAdd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Dbnd.Data.Entities.Character", b =>
                {
                    b.Property<Guid>("CharacterID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClientID")
                        .HasColumnType("uuid");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("character varying(75)")
                        .HasMaxLength(75);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("character varying(75)")
                        .HasMaxLength(75);

                    b.HasKey("CharacterID");

                    b.HasIndex("ClientID");

                    b.ToTable("Character");
                });

            modelBuilder.Entity("Dbnd.Data.Entities.CharacterGameXRef", b =>
                {
                    b.Property<Guid>("GameID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CharacterID")
                        .HasColumnType("uuid");

                    b.HasKey("GameID", "CharacterID");

                    b.HasIndex("CharacterID");

                    b.ToTable("CharacterGameXRef");
                });

            modelBuilder.Entity("Dbnd.Data.Entities.Client", b =>
                {
                    b.Property<Guid>("ClientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("character varying(175)")
                        .HasMaxLength(175);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("character varying(75)")
                        .HasMaxLength(75);

                    b.HasKey("ClientID");

                    b.HasAlternateKey("Email");

                    b.HasAlternateKey("UserName");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Dbnd.Data.Entities.DungeonMaster", b =>
                {
                    b.Property<Guid>("DungeonMasterID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClientID")
                        .HasColumnType("uuid");

                    b.HasKey("DungeonMasterID");

                    b.HasIndex("ClientID");

                    b.ToTable("DungeonMaster");
                });

            modelBuilder.Entity("Dbnd.Data.Entities.Game", b =>
                {
                    b.Property<Guid>("GameID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("DungeonMasterID")
                        .HasColumnType("uuid");

                    b.Property<string>("GameName")
                        .IsRequired()
                        .HasColumnType("character varying(225)")
                        .HasMaxLength(225);

                    b.HasKey("GameID");

                    b.HasAlternateKey("GameName");

                    b.HasIndex("DungeonMasterID");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("Dbnd.Data.Entities.Overview", b =>
                {
                    b.Property<Guid>("OverviewID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("GameID")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("OverviewTypeTypeID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TypeID")
                        .HasColumnType("uuid");

                    b.HasKey("OverviewID");

                    b.HasIndex("GameID");

                    b.HasIndex("OverviewTypeTypeID");

                    b.ToTable("Overview");
                });

            modelBuilder.Entity("Dbnd.Data.Entities.OverviewType", b =>
                {
                    b.Property<Guid>("TypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.HasKey("TypeID");

                    b.ToTable("OverviewType");
                });

            modelBuilder.Entity("Dbnd.Data.Entities.Character", b =>
                {
                    b.HasOne("Dbnd.Data.Entities.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dbnd.Data.Entities.CharacterGameXRef", b =>
                {
                    b.HasOne("Dbnd.Data.Entities.Character", "Character")
                        .WithMany()
                        .HasForeignKey("CharacterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dbnd.Data.Entities.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dbnd.Data.Entities.DungeonMaster", b =>
                {
                    b.HasOne("Dbnd.Data.Entities.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dbnd.Data.Entities.Game", b =>
                {
                    b.HasOne("Dbnd.Data.Entities.DungeonMaster", "DungeonMaster")
                        .WithMany()
                        .HasForeignKey("DungeonMasterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dbnd.Data.Entities.Overview", b =>
                {
                    b.HasOne("Dbnd.Data.Entities.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dbnd.Data.Entities.OverviewType", "OverviewType")
                        .WithMany()
                        .HasForeignKey("OverviewTypeTypeID");
                });
#pragma warning restore 612, 618
        }
    }
}
