﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PRDH.Data;

#nullable disable

namespace PRDH.Domain.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("PRDH.Domain.Models.Case", b =>
                {
                    b.Property<Guid>("CaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EarliestPositiveOrderTestSampleCollectedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("EarliestPositiveOrderTestType")
                        .HasColumnType("TEXT");

                    b.Property<int>("OrderTestCount")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("TEXT");

                    b.HasKey("CaseId");

                    b.ToTable("Cases");
                });
#pragma warning restore 612, 618
        }
    }
}
