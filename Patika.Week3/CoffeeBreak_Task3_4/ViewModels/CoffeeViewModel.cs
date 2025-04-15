using System.ComponentModel.DataAnnotations;

namespace CoffeeBreak_Task3_4.ViewModels;

public class CoffeeViewModel
{
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, ErrorMessage = "Name can be a maximum of 100 characters.")]
    public string Name { get; set; }

    [StringLength(500, ErrorMessage = "Description can be a maximum of 500 characters.")]
    public string? Description { get; set; }

    [Range(0.1, 100, ErrorMessage = "Price must be between 0.1 and 100.")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Size is required.")]
    public string Size { get; set; }

    [Required(ErrorMessage = "IsHot field is required.")]
    public bool IsHot { get; set; }

    [Required(ErrorMessage = "IsIced field is required.")]
    public bool IsIced { get; set; }

    public string? Ingredients { get; set; }

    [Range(0, 100, ErrorMessage = "Stock quantity must be between 0 and 100.")]
    public int StockQuantity { get; set; }

    public string? ImageUrl { get; set; }

    public IFormFile? ImageFile { get; set; }
}
