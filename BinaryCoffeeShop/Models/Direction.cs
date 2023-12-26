using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BinaryCoffeeShop.Models;

public class Direction
{
    [Key]
    public int DirectionId { get; set; }
    
    [Required]
    [StringLength(100)]
    public string Address { get; set; } = null!;
    
    [Required]
    [StringLength(50)]
    public string City { get; set; } = null!;
    
    [Required]
    [StringLength(50)]
    public string State { get; set; } = null!;
    
    [Required]
    [StringLength(10)]
    public string ZipCode { get; set; } = null!;

    [Required]
    public int UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User User { get; set; } = null!;
}
