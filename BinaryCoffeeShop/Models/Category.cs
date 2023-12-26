using System.ComponentModel.DataAnnotations;

namespace BinaryCoffeeShop.Models;

public class Category
{
    [Key]
    public int CategoryId { get; set; }
    
    [Required(ErrorMessage = "This field is mandatory")]
    [StringLength(50)]
    public string Name { get; set; } = null!;
    
    [Required]
    [StringLength(1000)]
    public string Description { get; set; } = null!;

    public ICollection<Product> Products { get; set; } = null!;

    public Category()
    {
        Products = new List<Product>();
    }
}
