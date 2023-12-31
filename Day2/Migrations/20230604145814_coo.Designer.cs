﻿// <auto-generated />
using Day2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Day2.Migrations
{
    [DbContext(typeof(DB_Context))]
    [Migration("20230604145814_coo")]
    partial class coo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Day2.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("degree")
                        .HasColumnType("float");

                    b.Property<int>("departmentId")
                        .HasColumnType("int");

                    b.Property<double>("minDegree")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("departmentId");

                    b.ToTable("courses");
                });

            modelBuilder.Entity("Day2.Models.CrsResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("courseId")
                        .HasColumnType("int");

                    b.Property<double>("degree")
                        .HasColumnType("float");

                    b.Property<int>("traineeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("courseId");

                    b.HasIndex("traineeId");

                    b.ToTable("results");
                });

            modelBuilder.Entity("Day2.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Manager")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("departments");
                });

            modelBuilder.Entity("Day2.Models.Instructor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("courseId")
                        .HasColumnType("int");

                    b.Property<int>("departmentId")
                        .HasColumnType("int");

                    b.Property<double>("salary")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("courseId");

                    b.HasIndex("departmentId");

                    b.ToTable("instructors");
                });

            modelBuilder.Entity("Day2.Models.Trainee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("departmentId")
                        .HasColumnType("int");

                    b.Property<string>("grade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("departmentId");

                    b.ToTable("trainees");
                });

            modelBuilder.Entity("Day2.Models.Course", b =>
                {
                    b.HasOne("Day2.Models.Department", "department")
                        .WithMany("Courses")
                        .HasForeignKey("departmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("department");
                });

            modelBuilder.Entity("Day2.Models.CrsResult", b =>
                {
                    b.HasOne("Day2.Models.Course", "course")
                        .WithMany("results")
                        .HasForeignKey("courseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Day2.Models.Trainee", "trainee")
                        .WithMany("Results")
                        .HasForeignKey("traineeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("course");

                    b.Navigation("trainee");
                });

            modelBuilder.Entity("Day2.Models.Instructor", b =>
                {
                    b.HasOne("Day2.Models.Course", "course")
                        .WithMany("Instructors")
                        .HasForeignKey("courseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Day2.Models.Department", "department")
                        .WithMany("Instructors")
                        .HasForeignKey("departmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("course");

                    b.Navigation("department");
                });

            modelBuilder.Entity("Day2.Models.Trainee", b =>
                {
                    b.HasOne("Day2.Models.Department", "department")
                        .WithMany("Trainees")
                        .HasForeignKey("departmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("department");
                });

            modelBuilder.Entity("Day2.Models.Course", b =>
                {
                    b.Navigation("Instructors");

                    b.Navigation("results");
                });

            modelBuilder.Entity("Day2.Models.Department", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Instructors");

                    b.Navigation("Trainees");
                });

            modelBuilder.Entity("Day2.Models.Trainee", b =>
                {
                    b.Navigation("Results");
                });
#pragma warning restore 612, 618
        }
    }
}
