using Microsoft.EntityFrameworkCore;
using Monopoly.NewDAL.Entities;

namespace Monopoly.NewDAL;

public class ApplicationDbContext : DbContext
{
    public virtual DbSet<Banknote> Banknotes { get; set; }

    public virtual DbSet<Card> Cards { get; set; }

    public virtual DbSet<CardType> CardTypes { get; set; }

    public virtual DbSet<Field> Fields { get; set; }

    public virtual DbSet<FieldType> FieldTypes { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Banknote>(entity =>
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

        builder.Entity<Card>(entity =>
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

        builder.Entity<CardType>(entity =>
        {
            entity.ToTable("card_type");

            entity.HasIndex(e => e.Id, "IX_card_type_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        builder.Entity<Field>(entity =>
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

        builder.Entity<FieldType>(entity =>
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

        builder.Entity<Game>(entity =>
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
    }
}