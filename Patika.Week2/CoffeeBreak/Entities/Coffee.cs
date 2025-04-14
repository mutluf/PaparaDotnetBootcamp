using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeBreak.Entities;

public class Coffee : BaseEntity
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [StringLength(500)]
    public string? Description { get; set; }

    [Range(0.1, 100)]
    public decimal Price { get; set; }

    [Required]
    public string Size { get; set; }

    [Required]
    public bool IsHot { get; set; }

    [Required]
    public bool IsIced { get; set; }

    public string? Ingredients { get; set; }

    [Range(0, 100)]
    public int StockQuantity { get; set; }

    public string? ImageUrl { get; set; }
}

public class CoffeeConfiguration : IEntityTypeConfiguration<Coffee>
{
    public void Configure(EntityTypeBuilder<Coffee> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Description)
            .HasMaxLength(500);

        builder.Property(x => x.Price)
            .IsRequired()
            .HasPrecision(18, 2);

        builder.Property(x => x.Size)
            .IsRequired();

        builder.Property(x => x.IsHot)
            .IsRequired();

        builder.Property(x => x.IsIced)
            .IsRequired();

        builder.Property(x => x.Ingredients)
            .HasMaxLength(1000);

        builder.Property(x => x.StockQuantity)
            .IsRequired();

        builder.Property(x => x.ImageUrl)
            .HasMaxLength(300);
    }
}
