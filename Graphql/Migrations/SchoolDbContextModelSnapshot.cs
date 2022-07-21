﻿// <auto-generated />
using System;
using Graphql.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Graphql.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    partial class SchoolDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.7");

            modelBuilder.Entity("CourseDTOStudentDTO", b =>
                {
                    b.Property<Guid>("Courseid")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("Studentsid")
                        .HasColumnType("TEXT");

                    b.HasKey("Courseid", "Studentsid");

                    b.HasIndex("Studentsid");

                    b.ToTable("CourseDTOStudentDTO");
                });

            modelBuilder.Entity("Graphql.Services.CourseDTO", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("InstructorId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Subject")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("InstructorId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Graphql.Services.InstructorDTO", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<double>("Salary")
                        .HasColumnType("REAL");

                    b.HasKey("id");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("Graphql.Services.StudentDTO", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<double>("GPA")
                        .HasColumnType("REAL");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("CourseDTOStudentDTO", b =>
                {
                    b.HasOne("Graphql.Services.CourseDTO", null)
                        .WithMany()
                        .HasForeignKey("Courseid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Graphql.Services.StudentDTO", null)
                        .WithMany()
                        .HasForeignKey("Studentsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Graphql.Services.CourseDTO", b =>
                {
                    b.HasOne("Graphql.Services.InstructorDTO", "Instructor")
                        .WithMany("Course")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("Graphql.Services.InstructorDTO", b =>
                {
                    b.Navigation("Course");
                });
#pragma warning restore 612, 618
        }
    }
}
