﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonalWebTool_V1.Models;

namespace PersonalWebTool_V1.Migrations
{
    [DbContext(typeof(BlogContext))]
    [Migration("20210111130154_Habit.Point-NonNullable")]
    partial class HabitPointNonNullable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("PersonalWebTool_V1.Models.BlogPost", b =>
                {
                    b.Property<int>("BlogPostID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostCategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BlogPostID");

                    b.HasIndex("PostCategoryID");

                    b.ToTable("BlogPosts");

                    b.HasData(
                        new
                        {
                            BlogPostID = 1,
                            Body = "This first blog post in my Personal Web Tool. This first blog post in my Personal Web Tool. This first blog post in my Personal Web Tool. This first blog post in my Personal Web Tool. ",
                            DateCreated = new DateTime(2021, 1, 11, 14, 1, 53, 878, DateTimeKind.Local).AddTicks(3109),
                            ImageName = "open-sign",
                            PostCategoryID = 4,
                            Title = "Initialize Personal Web Tool"
                        },
                        new
                        {
                            BlogPostID = 2,
                            Body = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                            DateCreated = new DateTime(2021, 1, 11, 14, 1, 53, 885, DateTimeKind.Local).AddTicks(3526),
                            ImageName = "vzhodne-alpe",
                            PostCategoryID = 1,
                            Title = "Initialize Personal Web Tool"
                        });
                });

            modelBuilder.Entity("PersonalWebTool_V1.Models.GratefulnessEntry", b =>
                {
                    b.Property<int>("GratefulnessEntryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.HasKey("GratefulnessEntryID");

                    b.ToTable("GratefulnessEntries");

                    b.HasData(
                        new
                        {
                            GratefulnessEntryID = 1,
                            DateCreated = new DateTime(2021, 1, 11, 14, 1, 53, 886, DateTimeKind.Local).AddTicks(875)
                        });
                });

            modelBuilder.Entity("PersonalWebTool_V1.Models.GratefulnessUnit", b =>
                {
                    b.Property<int>("GratefulnessUnitID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GratefulnessEntryID")
                        .HasColumnType("int");

                    b.Property<string>("Main")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GratefulnessUnitID");

                    b.HasIndex("GratefulnessEntryID");

                    b.ToTable("GratefulnessUnits");

                    b.HasData(
                        new
                        {
                            GratefulnessUnitID = 1,
                            Details = "Test1",
                            GratefulnessEntryID = 1,
                            Main = "test1"
                        });
                });

            modelBuilder.Entity("PersonalWebTool_V1.Models.Habit", b =>
                {
                    b.Property<int>("HabitID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.HasKey("HabitID");

                    b.ToTable("Habits");
                });

            modelBuilder.Entity("PersonalWebTool_V1.Models.HabitDay", b =>
                {
                    b.Property<int>("HabitDayID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Points")
                        .HasColumnType("int");

                    b.HasKey("HabitDayID");

                    b.ToTable("HabitDays");
                });

            modelBuilder.Entity("PersonalWebTool_V1.Models.HabitQuantity", b =>
                {
                    b.Property<string>("HabitQuantityID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Counter")
                        .HasColumnType("int");

                    b.Property<int>("HabitDayID")
                        .HasColumnType("int");

                    b.Property<int?>("HabitID")
                        .HasColumnType("int");

                    b.HasKey("HabitQuantityID");

                    b.HasIndex("HabitDayID");

                    b.HasIndex("HabitID");

                    b.ToTable("HabitQuantities");
                });

            modelBuilder.Entity("PersonalWebTool_V1.Models.PostCategory", b =>
                {
                    b.Property<int>("PostCategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PostCategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            PostCategoryID = 1,
                            Name = "Adventure"
                        },
                        new
                        {
                            PostCategoryID = 2,
                            Name = "Optimization"
                        },
                        new
                        {
                            PostCategoryID = 3,
                            Name = "Programming"
                        },
                        new
                        {
                            PostCategoryID = 4,
                            Name = "Miscellaneous"
                        });
                });

            modelBuilder.Entity("PersonalWebTool_V1.Models.BlogPost", b =>
                {
                    b.HasOne("PersonalWebTool_V1.Models.PostCategory", "Category")
                        .WithMany()
                        .HasForeignKey("PostCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("PersonalWebTool_V1.Models.GratefulnessUnit", b =>
                {
                    b.HasOne("PersonalWebTool_V1.Models.GratefulnessEntry", "GratefulnessEntry")
                        .WithMany("GratefulnessUnits")
                        .HasForeignKey("GratefulnessEntryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GratefulnessEntry");
                });

            modelBuilder.Entity("PersonalWebTool_V1.Models.HabitQuantity", b =>
                {
                    b.HasOne("PersonalWebTool_V1.Models.HabitDay", "HabitDay")
                        .WithMany("HabitQuantities")
                        .HasForeignKey("HabitDayID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PersonalWebTool_V1.Models.Habit", "Habit")
                        .WithMany()
                        .HasForeignKey("HabitID");

                    b.Navigation("Habit");

                    b.Navigation("HabitDay");
                });

            modelBuilder.Entity("PersonalWebTool_V1.Models.GratefulnessEntry", b =>
                {
                    b.Navigation("GratefulnessUnits");
                });

            modelBuilder.Entity("PersonalWebTool_V1.Models.HabitDay", b =>
                {
                    b.Navigation("HabitQuantities");
                });
#pragma warning restore 612, 618
        }
    }
}
