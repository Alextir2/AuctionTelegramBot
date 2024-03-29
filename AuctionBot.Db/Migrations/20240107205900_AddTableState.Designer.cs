﻿// <auto-generated />
using System;
using AuctionBot.Db.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AuctionBot.Db.Migrations
{
    [DbContext(typeof(AuctionBotDbContext))]
    [Migration("20240107205900_AddTableState")]
    partial class AddTableState
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AuctionBot.Db.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar");

                    b.Property<DateTime>("UpdateDt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDt = new DateTime(2024, 1, 7, 20, 59, 0, 846, DateTimeKind.Utc).AddTicks(867),
                            IsDeleted = false,
                            Name = "Овощи",
                            UpdateDt = new DateTime(2024, 1, 7, 20, 59, 0, 846, DateTimeKind.Utc).AddTicks(868)
                        },
                        new
                        {
                            Id = 2,
                            CreateDt = new DateTime(2024, 1, 7, 20, 59, 0, 846, DateTimeKind.Utc).AddTicks(871),
                            IsDeleted = false,
                            Name = "Фрукты",
                            UpdateDt = new DateTime(2024, 1, 7, 20, 59, 0, 846, DateTimeKind.Utc).AddTicks(871)
                        });
                });

            modelBuilder.Entity("AuctionBot.Db.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("varchar");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdateDt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Images", (string)null);
                });

            modelBuilder.Entity("AuctionBot.Db.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreateDt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("UpdateDt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreateDt = new DateTime(2024, 1, 7, 20, 59, 0, 846, DateTimeKind.Utc).AddTicks(3236),
                            IsDeleted = false,
                            Name = "Огурцы",
                            Price = 12m,
                            UpdateDt = new DateTime(2024, 1, 7, 20, 59, 0, 846, DateTimeKind.Utc).AddTicks(3237),
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            CreateDt = new DateTime(2024, 1, 7, 20, 59, 0, 846, DateTimeKind.Utc).AddTicks(3243),
                            IsDeleted = false,
                            Name = "Абрикосы",
                            Price = 10m,
                            UpdateDt = new DateTime(2024, 1, 7, 20, 59, 0, 846, DateTimeKind.Utc).AddTicks(3243),
                            UserId = 2
                        });
                });

            modelBuilder.Entity("AuctionBot.Db.Models.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("TelegramCommand")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateDt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("State");
                });

            modelBuilder.Entity("AuctionBot.Db.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte?>("Role")
                        .HasColumnType("smallint");

                    b.Property<int?>("StateId")
                        .HasColumnType("integer");

                    b.Property<long>("TelegramUserChatId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdateDt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDt = new DateTime(2024, 1, 7, 20, 59, 0, 845, DateTimeKind.Utc).AddTicks(9940),
                            IsDeleted = false,
                            Name = "@edgerun",
                            Role = (byte)2,
                            TelegramUserChatId = 1L,
                            UpdateDt = new DateTime(2024, 1, 7, 20, 59, 0, 845, DateTimeKind.Utc).AddTicks(9937)
                        },
                        new
                        {
                            Id = 2,
                            CreateDt = new DateTime(2024, 1, 7, 20, 59, 0, 845, DateTimeKind.Utc).AddTicks(9944),
                            IsDeleted = false,
                            Name = "@alextir2",
                            Role = (byte)1,
                            TelegramUserChatId = 2L,
                            UpdateDt = new DateTime(2024, 1, 7, 20, 59, 0, 845, DateTimeKind.Utc).AddTicks(9944)
                        });
                });

            modelBuilder.Entity("AuctionBot.Db.Models.Image", b =>
                {
                    b.HasOne("AuctionBot.Db.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("AuctionBot.Db.Models.Product", b =>
                {
                    b.HasOne("AuctionBot.Db.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AuctionBot.Db.Models.User", "User")
                        .WithMany("Products")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AuctionBot.Db.Models.User", b =>
                {
                    b.HasOne("AuctionBot.Db.Models.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId");

                    b.Navigation("State");
                });

            modelBuilder.Entity("AuctionBot.Db.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("AuctionBot.Db.Models.User", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
