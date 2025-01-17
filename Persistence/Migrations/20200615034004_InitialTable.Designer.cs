﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200615034004_InitialTable")]
    partial class InitialTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("Domain.Account", b =>
                {
                    b.Property<string>("NameLogin")
                        .HasColumnType("TEXT")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int?>("IdTeacher")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("IsEnable")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.HasKey("NameLogin")
                        .HasName("PK_Account");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Domain.ClassRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Identity")
                        .HasColumnType("TEXT");

                    b.Property<int>("SemesterId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SubjectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id")
                        .HasName("PK_ClassRoom");

                    b.HasIndex("SemesterId");

                    b.HasIndex("SubjectId");

                    b.ToTable("ClassRooms");
                });

            modelBuilder.Entity("Domain.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SubjectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id")
                        .HasName("PK_Order");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Domain.PointTest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double?>("Ck")
                        .HasColumnName("CK")
                        .HasColumnType("REAL");

                    b.Property<int?>("ClassRoomId")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("Gk")
                        .HasColumnName("GK")
                        .HasColumnType("REAL");

                    b.Property<int?>("IdStudent")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("Th")
                        .HasColumnName("TH")
                        .HasColumnType("REAL");

                    b.Property<double?>("Tk")
                        .HasColumnName("TK")
                        .HasColumnType("REAL");

                    b.HasKey("Id")
                        .HasName("PK_PointTest");

                    b.HasIndex("ClassRoomId");

                    b.HasIndex("IdStudent");

                    b.ToTable("PointTests");
                });

            modelBuilder.Entity("Domain.Semester", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id")
                        .HasName("PK_Semester");

                    b.ToTable("Semesters");
                });

            modelBuilder.Entity("Domain.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.Property<bool?>("Sex")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id")
                        .HasName("PK_Student");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Domain.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.HasKey("Id")
                        .HasName("PK_Subject");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Domain.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("Degree")
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<DateTime>("Dob")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.Property<bool?>("Sex")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id")
                        .HasName("PK_Teacher");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Domain.Teaching", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClassRoomId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("IdTeacher")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Location")
                        .HasColumnType("TEXT");

                    b.Property<string>("TeachDay")
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.HasKey("Id")
                        .HasName("PK_Teaching");

                    b.HasIndex("ClassRoomId");

                    b.HasIndex("IdTeacher");

                    b.ToTable("Teachings");
                });

            modelBuilder.Entity("Domain.ClassRoom", b =>
                {
                    b.HasOne("Domain.Semester", "Semester")
                        .WithMany("ClassRooms")
                        .HasForeignKey("SemesterId")
                        .HasConstraintName("FK_ClassRoom_Semester")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Subject", "Subject")
                        .WithMany("ClassRooms")
                        .HasForeignKey("SubjectId")
                        .HasConstraintName("FK_ClassRoom_Subject")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Order", b =>
                {
                    b.HasOne("Domain.Student", "Student")
                        .WithMany("Orders")
                        .HasForeignKey("StudentId")
                        .HasConstraintName("FK_Order_Student")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Subject", "Subject")
                        .WithMany("Orders")
                        .HasForeignKey("SubjectId")
                        .HasConstraintName("FK_Order_Subject")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.PointTest", b =>
                {
                    b.HasOne("Domain.ClassRoom", "ClassRoom")
                        .WithMany("PointTest")
                        .HasForeignKey("ClassRoomId")
                        .HasConstraintName("FK_PointTest_ClassRoom");

                    b.HasOne("Domain.Student", "Student")
                        .WithMany("PointTest")
                        .HasForeignKey("IdStudent")
                        .HasConstraintName("FK_PointTest_Student");
                });

            modelBuilder.Entity("Domain.Teaching", b =>
                {
                    b.HasOne("Domain.ClassRoom", "ClassRoom")
                        .WithMany("Teaching")
                        .HasForeignKey("ClassRoomId")
                        .HasConstraintName("FK_Teaching_ClassRoom");

                    b.HasOne("Domain.Teacher", "Teacher")
                        .WithMany("Teaching")
                        .HasForeignKey("IdTeacher")
                        .HasConstraintName("FK_Teaching_Teacher");
                });
#pragma warning restore 612, 618
        }
    }
}
