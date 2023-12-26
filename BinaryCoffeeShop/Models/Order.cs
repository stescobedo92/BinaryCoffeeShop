using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BinaryCoffeeShop.Models;

public class Order
{
    [Key]
    public int OrderId { get; set; }

    [Required]
    public int UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User User { get; set; } = null!;

    public DateTime Date { get; set; }

    public string State { get; set; } = null!;

    public int SelectedDirectionId { get; set; }

    public Direction Direction { get; set; } = null!;

    public decimal Total { get; set; }

    public ICollection<ProductDetail> ProductDetails { get; set; } = null!;
}
