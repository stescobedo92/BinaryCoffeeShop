using System.ComponentModel.DataAnnotations;

namespace BinaryCoffeeShop.Models;

public class Role
{
    [Key]
    public int RoleId { get; set; }
    
    [Required(ErrorMessage = "This field is mandatory")]
    [StringLength(50)]
    public string RoleName { get; set; } = null!;
}
