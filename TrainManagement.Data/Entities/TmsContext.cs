using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TrainManagement.Data.Entities;

public partial class TmsContext : DbContext
{
    public TmsContext()
    {
    }

    public TmsContext(DbContextOptions<TmsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblTrain> TblTrains { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=TMS;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblTrain>(entity =>
        {
            entity.HasKey(e => e.TrainId);

            entity.ToTable("tblTrain");

            entity.Property(e => e.TrainId).ValueGeneratedNever();
            entity.Property(e => e.ArrivalDateTime).HasColumnType("datetime");
            entity.Property(e => e.DepartureDateTime).HasColumnType("datetime");
            entity.Property(e => e.DestinationStation)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Pnrnumber)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("PNRNumber");
            entity.Property(e => e.SourceStation)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TrainName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
