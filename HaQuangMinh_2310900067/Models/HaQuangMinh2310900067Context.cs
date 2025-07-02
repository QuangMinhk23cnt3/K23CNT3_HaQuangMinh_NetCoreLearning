using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HaQuangMinh_2310900067.Models;

public partial class HaQuangMinh2310900067Context : DbContext
{
    public HaQuangMinh2310900067Context()
    {
    }

    public HaQuangMinh2310900067Context(DbContextOptions<HaQuangMinh2310900067Context> options)
        : base(options)
    {
    }

    public virtual DbSet<HqmEmployeee> HqmEmployeees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-E55B6HI\\MAYTINH1;Database=HaQuangMinh_2310900067;uid=sa;pwd=minh1234; MultipleActiveResultSets=True; TrustServerCertificate=True ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HqmEmployeee>(entity =>
        {
            entity.HasKey(e => e.HqmEmpId).HasName("PK__HqmEmplo__1FD8F96CEDB02375");

            entity.ToTable("HqmEmployeee");

            entity.Property(e => e.HqmEmpId)
                .ValueGeneratedNever()
                .HasColumnName("hqmEmpId");
            entity.Property(e => e.HqmEmpLevel)
                .HasMaxLength(50)
                .HasColumnName("hqmEmpLevel");
            entity.Property(e => e.HqmEmpName)
                .HasMaxLength(100)
                .HasColumnName("hqmEmpName");
            entity.Property(e => e.HqmEmpStartDate).HasColumnName("hqmEmpStartDate");
            entity.Property(e => e.HqmEmpStatus).HasColumnName("hqmEmpStatus");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
