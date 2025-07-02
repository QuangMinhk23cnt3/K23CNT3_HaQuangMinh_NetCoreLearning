using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HqmLesson10EF.Models;

public partial class HqmK23cnt3Leson10DbContext : DbContext
{
    public HqmK23cnt3Leson10DbContext()
    {
    }

    public HqmK23cnt3Leson10DbContext(DbContextOptions<HqmK23cnt3Leson10DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<HqmPost> HqmPosts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-E55B6HI\\MAYTINH1;Database=HqmK23CNT3_Leson10Db;uid=sa;pwd=minh1234; MultipleActiveResultSets=True; TrustServerCertificate=True ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HqmPost>(entity =>
        {
            entity.HasKey(e => e.HqmId);

            entity.ToTable("HqmPost");

            entity.Property(e => e.HqmId)
                .ValueGeneratedNever()
                .HasColumnName("hqmId");
            entity.Property(e => e.HqmContent)
                .HasColumnType("ntext")
                .HasColumnName("hqmContent");
            entity.Property(e => e.HqmImage)
                .HasMaxLength(50)
                .HasColumnName("hqmImage");
            entity.Property(e => e.HqmStatus).HasColumnName("hqmStatus");
            entity.Property(e => e.HqmTitle)
                .HasMaxLength(50)
                .HasColumnName("hqmTitle");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
