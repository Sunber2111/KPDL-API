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

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<PointTest> PointTests { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Teaching> Teachings { get; set; }
        public virtual DbSet<Order> Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.NameLogin)
                    .HasName("PK_Account");

                entity.Property(e => e.NameLogin)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PointTest>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_PointTest");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Ck).HasColumnName("CK");

                entity.Property(e => e.Gk).HasColumnName("GK");

                entity.Property(e => e.Th).HasColumnName("TH");

                entity.Property(e => e.Tk).HasColumnName("TK");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.PointTest)
                    .HasForeignKey(d => d.IdStudent)
                    .HasConstraintName("FK_PointTest_Student");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.PointTest)
                    .HasForeignKey(d => d.IdSubject)
                    .HasConstraintName("FK_PointTest_Subject");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasKey(e => e.Id).HasName("PK_Student");

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
                 entity.HasKey(e => e.Id).HasName("PK_Subject");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasKey(e=>e.Id).HasName("PK_Teacher");

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
                entity.HasKey(e => e.Id).HasName("PK_Teaching");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.TeachDay).HasMaxLength(50);

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Teaching)
                    .HasForeignKey(d => d.IdSubject)
                    .HasConstraintName("FK_Teaching_Subject");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Teaching)
                    .HasForeignKey(d => d.IdTeacher)
                    .HasConstraintName("FK_Teaching_Teacher");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Order");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_Order_Subject");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_Order_Student");
            });

        }


    }
}
