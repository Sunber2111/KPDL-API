using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<PointTest> PointTest { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<Teaching> Teaching { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.NameLogin)
                    .HasName("PK_Account_1");

                entity.Property(e => e.NameLogin)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PointTest>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Ck).HasColumnName("CK");

                entity.Property(e => e.Gk).HasColumnName("GK");

                entity.Property(e => e.Th).HasColumnName("TH");

                entity.Property(e => e.Tk).HasColumnName("TK");

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.PointTest)
                    .HasForeignKey(d => d.IdStudent)
                    .HasConstraintName("FK_PointTest_Student");

                entity.HasOne(d => d.IdSubjectNavigation)
                    .WithMany(p => p.PointTest)
                    .HasForeignKey(d => d.IdSubject)
                    .HasConstraintName("FK_PointTest_Subject");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Degree).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Teaching>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.TeachDay).HasMaxLength(50);

                entity.HasOne(d => d.IdSubjectNavigation)
                    .WithMany(p => p.Teaching)
                    .HasForeignKey(d => d.IdSubject)
                    .HasConstraintName("FK_Teaching_Subject");

                entity.HasOne(d => d.IdTeacherNavigation)
                    .WithMany(p => p.Teaching)
                    .HasForeignKey(d => d.IdTeacher)
                    .HasConstraintName("FK_Teaching_Teacher");
            });

        }


    }
}
