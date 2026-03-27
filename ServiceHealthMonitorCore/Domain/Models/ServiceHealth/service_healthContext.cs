using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ServiceHealthMonitorCore.Domain.Models.ServiceHealth;

public partial class service_healthContext : DbContext
{
    public service_healthContext()
    {
    }

    public service_healthContext(DbContextOptions<service_healthContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Configuration> Configurations { get; set; }

    public virtual DbSet<ServiceHistory> ServiceHistories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Configuration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("configuration_pkey");

            entity.ToTable("configuration");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.Data).HasColumnName("DATA");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("MODIFIED_DATE");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<ServiceHistory>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.Name }).HasName("service_history_pkey");

            entity.ToTable("service_history");

            entity.HasIndex(e => e.History, "idx_service_history_history")
                .HasMethod("gin")
                .HasOperators(new[] { "jsonb_path_ops" });

            entity.HasIndex(e => e.Name, "idx_service_history_name");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_date");
            entity.Property(e => e.History)
                .HasColumnType("jsonb")
                .HasColumnName("history");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modified_date");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
