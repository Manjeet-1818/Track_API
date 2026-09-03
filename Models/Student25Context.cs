using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BuildAPI.Models;

public partial class Student25Context : DbContext
{
    public Student25Context()
    {
    }

    public Student25Context(DbContextOptions<Student25Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Detail> Details { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Detail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Details__3213E83F6D2CD8FC");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
