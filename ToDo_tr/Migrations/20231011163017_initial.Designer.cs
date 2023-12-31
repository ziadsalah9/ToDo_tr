﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDo_tr.Models;

#nullable disable

namespace ToDo_tr.Migrations
{
    [DbContext(typeof(ToDocontext))]
    [Migration("20231011163017_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ToDo_tr.Models.Category", b =>
                {
                    b.Property<string>("Categoryid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Categoryid");

                    b.ToTable("categories");

                    b.HasData(
                        new
                        {
                            Categoryid = "work",
                            Name = "Work"
                        },
                        new
                        {
                            Categoryid = "home",
                            Name = "Home"
                        },
                        new
                        {
                            Categoryid = "ex",
                            Name = "Exercise"
                        },
                        new
                        {
                            Categoryid = "shop",
                            Name = "Shopping"
                        },
                        new
                        {
                            Categoryid = "call",
                            Name = "Contact"
                        });
                });

            modelBuilder.Entity("ToDo_tr.Models.Status", b =>
                {
                    b.Property<string>("StatusId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("statuss");

                    b.HasData(
                        new
                        {
                            StatusId = "open",
                            Name = "Open"
                        },
                        new
                        {
                            StatusId = "closed",
                            Name = "Completed"
                        });
                });

            modelBuilder.Entity("ToDo_tr.Models.ToDO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Categoryid")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Duedate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("StatusId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Categoryid");

                    b.HasIndex("StatusId");

                    b.ToTable("ToDos");
                });

            modelBuilder.Entity("ToDo_tr.Models.ToDO", b =>
                {
                    b.HasOne("ToDo_tr.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("Categoryid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ToDo_tr.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Status");
                });
#pragma warning restore 612, 618
        }
    }
}
