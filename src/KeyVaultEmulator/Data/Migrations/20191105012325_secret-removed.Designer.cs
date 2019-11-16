﻿// <auto-generated />
using System;
using AzureKeyVaultEmulator.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AzureKeyVaultEmulator.Data.Migrations
{
    [DbContext(typeof(KeyVaultEmulatorContext))]
    [Migration("20191105012325_secret-removed")]
    partial class secretremoved
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0");

            modelBuilder.Entity("AzureKeyVaultEmulator.Data.Certificate", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Certificates");
                });

            modelBuilder.Entity("AzureKeyVaultEmulator.Data.Key", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ActivationDateUtc")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ExpirationDateUtc")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("PublicKey")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Keys");
                });

            modelBuilder.Entity("AzureKeyVaultEmulator.Data.Secret", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ContentType")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("Enabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Expires")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("NotBefore")
                        .HasColumnType("TEXT");

                    b.Property<string>("RecoveryLevel")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Removed")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.Property<string>("VersionId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Secrets");
                });

            modelBuilder.Entity("AzureKeyVaultEmulator.Data.Secret", b =>
                {
                    b.OwnsMany("AzureKeyVaultEmulator.Data.Tag", "Tags", b1 =>
                        {
                            b1.Property<long>("SecretId")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Key")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Value")
                                .HasColumnType("TEXT");

                            b1.HasKey("SecretId", "Id");

                            b1.ToTable("Tag");

                            b1.WithOwner()
                                .HasForeignKey("SecretId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}