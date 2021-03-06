﻿// <auto-generated />
using System;
using EFPlusTest.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(TestEfContext))]
    [Migration("20201111163902_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("EFPlusTest.Domain.MainEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<Guid>("TestRound")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TestRound");

                    b.ToTable("MainEntitites");
                });

            modelBuilder.Entity("EFPlusTest.Domain.SecondaryEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<Guid>("MainEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PropertyA")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("PropertyB")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("PropertyC")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("MainEntityId");

                    b.ToTable("SecondaryEntity");
                });

            modelBuilder.Entity("EFPlusTest.Domain.SecondaryEntity", b =>
                {
                    b.HasOne("EFPlusTest.Domain.MainEntity", null)
                        .WithMany("Secondaries")
                        .HasForeignKey("MainEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFPlusTest.Domain.MainEntity", b =>
                {
                    b.Navigation("Secondaries");
                });
#pragma warning restore 612, 618
        }
    }
}
