﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentEnrolment.Data;

#nullable disable

namespace StudentEnrolment.Migrations
{
    [DbContext(typeof(EnrolmentDbContext))]
    [Migration("20220526013755_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("StudentEnrolment.Models.CourseStudent", b =>
                {
                    b.Property<string>("CourseId")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("StudentId")
                        .HasColumnType("varchar(36)");

                    b.HasKey("CourseId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("CourseStudent");
                });

            modelBuilder.Entity("StudentEnrolment.Models.CourseSubject", b =>
                {
                    b.Property<string>("CourseId")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("SubjectId")
                        .HasColumnType("varchar(36)");

                    b.HasKey("CourseId", "SubjectId");

                    b.HasIndex("SubjectId");

                    b.ToTable("CourseSubject");
                });

            modelBuilder.Entity("StudentEnrolment.Models.EntityModels.Course", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsPartFunded")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("StudentEnrolment.Models.EntityModels.Student", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(70)");

                    b.HasKey("Id");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("StudentEnrolment.Models.EntityModels.Subject", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("StudentEnrolment.Models.CourseStudent", b =>
                {
                    b.HasOne("StudentEnrolment.Models.EntityModels.Student", "Student")
                        .WithMany("CourseStudent")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentEnrolment.Models.EntityModels.Course", "Course")
                        .WithMany("CourseStudent")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("StudentEnrolment.Models.CourseSubject", b =>
                {
                    b.HasOne("StudentEnrolment.Models.EntityModels.Subject", "Subject")
                        .WithMany("CourseSubject")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentEnrolment.Models.EntityModels.Course", "Course")
                        .WithMany("CourseSubject")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("StudentEnrolment.Models.EntityModels.Course", b =>
                {
                    b.Navigation("CourseStudent");

                    b.Navigation("CourseSubject");
                });

            modelBuilder.Entity("StudentEnrolment.Models.EntityModels.Student", b =>
                {
                    b.Navigation("CourseStudent");
                });

            modelBuilder.Entity("StudentEnrolment.Models.EntityModels.Subject", b =>
                {
                    b.Navigation("CourseSubject");
                });
#pragma warning restore 612, 618
        }
    }
}