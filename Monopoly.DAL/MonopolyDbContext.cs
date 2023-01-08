using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Monopoly.Model.Entities;
namespace Monopoly.DAL;

public partial class MonopolyDbContext : DbContext
{
    public MonopolyDbContext()
    {
    }

    public MonopolyDbContext(DbContextOptions<MonopolyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Banknote> Banknotes { get; set; }

    public virtual DbSet<Card> Cards { get; set; }

    public virtual DbSet<CardType> CardTypes { get; set; }

    public virtual DbSet<Field> Fields { get; set; }

    public virtual DbSet<FieldType> FieldTypes { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("DataSource=D:\\source\\repos\\monopoly\\monopolyDB.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Banknote>(entity =>
        {
            entity.ToTable("Banknote");

            entity.HasIndex(e => e.Id, "IX_Banknote_Id").IsUnique();

            entity.Property(e => e.Unit).IsRequired();
        });

        modelBuilder.Entity<Card>(entity =>
        {
            entity.ToTable("Card");

            entity.HasIndex(e => e.Id, "IX_Card_Id").IsUnique();

            entity.Property(e => e.Description).IsRequired();
            entity.Property(e => e.Name).IsRequired();
        });

        modelBuilder.Entity<CardType>(entity =>
        {
            entity.ToTable("CardType");

            entity.HasIndex(e => e.Id, "IX_CardType_Id").IsUnique();
        });

        modelBuilder.Entity<Field>(entity =>
        {
            entity.ToTable("Field");

            entity.HasIndex(e => e.Id, "IX_Field_Id").IsUnique();

            entity.Property(e => e.Name).IsRequired();
        });

        modelBuilder.Entity<FieldType>(entity =>
        {
            entity.ToTable("FieldType");

            entity.HasIndex(e => e.Id, "IX_FieldType_Id").IsUnique();

            entity.Property(e => e.Description).IsRequired();
            entity.Property(e => e.Name).IsRequired();
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.ToTable("Game");

            entity.HasIndex(e => e.Id, "IX_Game_Id").IsUnique();

            entity.Property(e => e.Name).IsRequired();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
