﻿// <auto-generated />
using System;
using DiaryAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DiaryAPI.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20220701113340_InitialCrreation")]
    partial class InitialCrreation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DiaryAPI.Models.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DayEvent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("DiaryAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasComment("user email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("user first name");

                    b.Property<string>("Gender")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasComment("user gender");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(250)
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasComment("user email");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("user last name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("user password");

                    b.Property<DateTime?>("RegisteredOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()")
                        .HasComment("user registering date and time");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("user username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DiaryAPI.Models.Note", b =>
                {
                    b.HasOne("DiaryAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
