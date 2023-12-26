using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BinaryCoffeeShop.Models;

public class User
{
    [Key]
    public int UsertId { get; set; }
    [Required]
    [StringLength(50)]
    public string Name { get; set; } = null!;

    [Required]
    [StringLength(11)]
    public string PhoneNumber { get; set; } = null!;
    
    [Required]
    [StringLength(50)]
    public string Alias { get; set; } = null!;
    
    [Required]
    [StringLength(12)]
    public string Password { get; set; } = null!;
    
    [Required]
    [StringLength(50)]
    public string Email { get; set; } = null!;
    
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
    public int RoleId { get; set; }
    
    [ForeignKey(nameof(RoleId))]
    public Role Role { get; set; } = null!;
    
    public ICollection<Order> Orders { get; set; } = null!;
    
    [InverseProperty(nameof(User))]
    public ICollection<Direction> Directions { get; set; } = null!;

    public User()
    {
        Orders = new List<Order>();
    }
}
