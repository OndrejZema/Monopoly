using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Monopoly.DAL.Entities;

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
        => optionsBuilder.UseSqlite("DataSource=D:\\source\\repos\\monopoly\\monopolydb.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Banknote>(entity =>
        {
            entity.ToTable("banknote");

            entity.HasIndex(e => e.Id, "IX_banknote_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.GameId).HasColumnName("game_id");
            entity.Property(e => e.Unit)
                .IsRequired()
                .HasColumnName("unit");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<Card>(entity =>
        {
            entity.ToTable("card");

            entity.HasIndex(e => e.Id, "IX_card_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CardTypeId).HasColumnName("card_type_id");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasColumnName("description");
            entity.Property(e => e.GameId).HasColumnName("game_id");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name");
        });

        modelBuilder.Entity<CardType>(entity =>
        {
            entity.ToTable("card_type");

            entity.HasIndex(e => e.Id, "IX_card_type_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Field>(entity =>
        {
            entity.ToTable("field");

            entity.HasIndex(e => e.Id, "IX_field_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasColumnName("description");
            entity.Property(e => e.FieldTypeId).HasColumnName("field_type_id");
            entity.Property(e => e.GameId).HasColumnName("game_id");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name");
        });

        modelBuilder.Entity<FieldType>(entity =>
        {
            entity.ToTable("field_type");

            entity.HasIndex(e => e.Id, "IX_field_type_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name");
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.ToTable("game");

            entity.HasIndex(e => e.Id, "IX_game_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IsCompleted).HasColumnName("is_completed");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
