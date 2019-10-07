﻿// <auto-generated />
using System;
using KeyVaultEmulator.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AzureKeyVaultEmulator.Data.Migrations
{
    [DbContext(typeof(KeyVaultEmulatorContext))]
    partial class KeyVaultEmulatorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0");

            modelBuilder.Entity("KeyVaultEmulator.Data.Certificate", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Certificates");
                });

            modelBuilder.Entity("KeyVaultEmulator.Data.Key", b =>
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

            modelBuilder.Entity("KeyVaultEmulator.Data.Secret", b =>
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

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Secrets");
                });

            modelBuilder.Entity("KeyVaultEmulator.Data.SecretTag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("FkSecretKey")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Key")
                        .HasColumnType("TEXT");

                    b.Property<long?>("SecretId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SecretId");

                    b.ToTable("SecretTag");
                });

            modelBuilder.Entity("KeyVaultEmulator.Data.SecretTag", b =>
                {
                    b.HasOne("KeyVaultEmulator.Data.Secret", "Secret")
                        .WithMany("Tags")
                        .HasForeignKey("SecretId");
                });
#pragma warning restore 612, 618
        }
    }
}