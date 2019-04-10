﻿// <auto-generated />
using System;
using Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(FamilyWalletContext))]
    partial class FamilyWalletContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085");

            modelBuilder.Entity("Domain.Entity.Family", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Family");
                });

            modelBuilder.Entity("Domain.Entity.Operation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("OperationCategoryID")
                        .IsRequired();

                    b.Property<int?>("OperationInfoID")
                        .IsRequired();

                    b.Property<int?>("PersonWalletID")
                        .IsRequired();

                    b.Property<int?>("TransactionID");

                    b.HasKey("ID");

                    b.HasIndex("OperationCategoryID");

                    b.HasIndex("OperationInfoID");

                    b.HasIndex("PersonWalletID");

                    b.HasIndex("TransactionID");

                    b.ToTable("Operation");
                });

            modelBuilder.Entity("Domain.Entity.OperationCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Type");

                    b.HasKey("ID");

                    b.ToTable("OperationCategory");
                });

            modelBuilder.Entity("Domain.Entity.OperationInfo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Balance");

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Date")
                        .HasDefaultValueSql("GetDate()");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("OperationInfo");
                });

            modelBuilder.Entity("Domain.Entity.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Surname")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("Domain.Entity.PersonFamily", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("FamilyID")
                        .IsRequired();

                    b.Property<int?>("PersonID")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("FamilyID");

                    b.HasIndex("PersonID");

                    b.ToTable("PersonFamily");
                });

            modelBuilder.Entity("Domain.Entity.PersonWallet", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessModifier");

                    b.Property<int?>("PersonID")
                        .IsRequired();

                    b.Property<int?>("WalletID")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("PersonID");

                    b.HasIndex("WalletID");

                    b.ToTable("PersonWallet");
                });

            modelBuilder.Entity("Domain.Entity.Transaction", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.HasKey("ID");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("Domain.Entity.Wallet", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Balance");

                    b.Property<int?>("FamilyID");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Type");

                    b.HasKey("ID");

                    b.HasIndex("FamilyID");

                    b.ToTable("Wallet");
                });

            modelBuilder.Entity("Domain.Entity.Operation", b =>
                {
                    b.HasOne("Domain.Entity.OperationCategory", "OperationCategory")
                        .WithMany("Operations")
                        .HasForeignKey("OperationCategoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entity.OperationInfo", "OperationInfo")
                        .WithMany("Operations")
                        .HasForeignKey("OperationInfoID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entity.PersonWallet", "PersonWallet")
                        .WithMany("Operations")
                        .HasForeignKey("PersonWalletID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entity.Transaction", "Transaction")
                        .WithMany("Operations")
                        .HasForeignKey("TransactionID");
                });

            modelBuilder.Entity("Domain.Entity.PersonFamily", b =>
                {
                    b.HasOne("Domain.Entity.Family", "Family")
                        .WithMany("PersonFamilies")
                        .HasForeignKey("FamilyID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entity.Person", "Person")
                        .WithMany("PersonFamilies")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entity.PersonWallet", b =>
                {
                    b.HasOne("Domain.Entity.Person", "Person")
                        .WithMany("PersonWallets")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entity.Wallet", "Wallet")
                        .WithMany("PersonWallets")
                        .HasForeignKey("WalletID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entity.Wallet", b =>
                {
                    b.HasOne("Domain.Entity.Family", "Family")
                        .WithMany("Wallets")
                        .HasForeignKey("FamilyID");
                });
#pragma warning restore 612, 618
        }
    }
}
