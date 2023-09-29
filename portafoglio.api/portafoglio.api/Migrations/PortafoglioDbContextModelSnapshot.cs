﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using portafoglio.api.Contextes;

#nullable disable

namespace portafoglio.api.Migrations
{
    [DbContext(typeof(PortafoglioDbContext))]
    partial class PortafoglioDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("portafoglio.api.Models.Entities.Earning", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IdUser")
                        .HasColumnType("TEXT");

                    b.Property<int>("Value")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("Earnings");
                });

            modelBuilder.Entity("portafoglio.api.Models.Entities.EarningSuddivision", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IdUser")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Percentage")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("IdUser", "Name")
                        .IsUnique();

                    b.ToTable("EarningSuddivisions");
                });

            modelBuilder.Entity("portafoglio.api.Models.Entities.Label", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IdEarningSuddivision")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("IdFatherLabel")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("IdFatherLabel");

                    b.HasIndex("IdEarningSuddivision", "Name")
                        .IsUnique();

                    b.ToTable("Labels");
                });

            modelBuilder.Entity("portafoglio.api.Models.Entities.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IdLabel")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IdWallet")
                        .HasColumnType("TEXT");

                    b.Property<int>("Value")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Date");

                    b.HasIndex("IdLabel");

                    b.HasIndex("IdWallet");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("portafoglio.api.Models.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("portafoglio.api.Models.Entities.Wallet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IdUser")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Money")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("IdUser", "Name")
                        .IsUnique();

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("portafoglio.api.Models.Entities.Earning", b =>
                {
                    b.HasOne("portafoglio.api.Models.Entities.User", "User")
                        .WithMany("Earnings")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("portafoglio.api.Models.Entities.EarningSuddivision", b =>
                {
                    b.HasOne("portafoglio.api.Models.Entities.User", "User")
                        .WithMany("EarningSuddivisions")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("portafoglio.api.Models.Entities.Label", b =>
                {
                    b.HasOne("portafoglio.api.Models.Entities.Label", "FatherLabel")
                        .WithMany("FatherLabels")
                        .HasForeignKey("IdFatherLabel");

                    b.Navigation("FatherLabel");
                });

            modelBuilder.Entity("portafoglio.api.Models.Entities.Transaction", b =>
                {
                    b.HasOne("portafoglio.api.Models.Entities.Label", "Label")
                        .WithMany("Transactions")
                        .HasForeignKey("IdLabel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("portafoglio.api.Models.Entities.Wallet", "Wallet")
                        .WithMany("Transactions")
                        .HasForeignKey("IdWallet")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Label");

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("portafoglio.api.Models.Entities.Wallet", b =>
                {
                    b.HasOne("portafoglio.api.Models.Entities.User", "User")
                        .WithMany("Wallets")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("portafoglio.api.Models.Entities.Label", b =>
                {
                    b.Navigation("FatherLabels");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("portafoglio.api.Models.Entities.User", b =>
                {
                    b.Navigation("EarningSuddivisions");

                    b.Navigation("Earnings");

                    b.Navigation("Wallets");
                });

            modelBuilder.Entity("portafoglio.api.Models.Entities.Wallet", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
