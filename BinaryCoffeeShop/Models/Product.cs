using System.ComponentModel.DataAnnotations;

namespace BinaryCoffeeShop.Models;

public class Product
{
    [Key]
    public int ProductId { get; set; }
    
    [Required]
    [StringLength(50)]
    public string Code { get; set; } = null!;
    
    [Required]
    [StringLength(50)]
    public string Name { get; set; } = null!;
    
    [Required]
    [StringLength(50)]
    public string Model { get; set; } = null!;
    
    [Required]
    [StringLength(100)]
    public string Description { get; set; } = null!;
    
    [Required]
    public decimal Price { get; set; }
    
    [Required]
    public string Image { get; set; } = null!;
    
    [Required]
    public int CategoryId { get; set; }
    
    public Category Category { get; set; } = null!;
    
    [Required]
    public int Stock { get; set; }
    
    [Required]
    [StringLength(20)]
    public string Brand { get; set; } = null!;
    
    public bool IsActive { get; set; }
    
    public ICollection<ProductDetail> ProductDetails { get; set; } = null!;
}
