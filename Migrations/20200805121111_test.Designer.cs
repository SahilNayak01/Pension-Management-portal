﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pension_Management_Portal.Models;

namespace Pension_Management_Portal.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200805121111_test")]
    partial class test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Pension_Management_Portal.Models.PensionDetail", b =>
                {
                    b.Property<int>("serialNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("aadharNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("pan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("pensionAmount")
                        .HasColumnType("int");

                    b.Property<int>("pensionType")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("serialNumber");

                    b.ToTable("pensionDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
