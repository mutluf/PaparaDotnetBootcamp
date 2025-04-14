namespace CoffeeBreak.DTOs;

public class CoffeeDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public string Size { get; set; }

    public bool IsHot { get; set; }

    public bool IsIced { get; set; }

    public string? Ingredients { get; set; }

    public int StockQuantity { get; set; }

    public string? ImageUrl { get; set; }
}
