﻿// <auto-generated />
using System;
using BlazorTasks.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorTasks.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231016174825_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.12");

            modelBuilder.Entity("BlazorTasks.Core.Models.TaskModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
