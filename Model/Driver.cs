using System; 
using System.ComponentModel.DataAnnotations; 
using System.ComponentModel.DataAnnotations.Schema; 

namespace TestServer.Models;

public class Driver
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Tự động tăng giá trị
    public int Id { get; set; }

    [Required]
    [StringLength(100)] 
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(100)] // Lưu ý: Cần dùng StringLength
    public string LicenseNumber { get; set; } = string.Empty;

    [StringLength(20)]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    [StringLength(200)]
    public string Car { get; set; } = string.Empty;
}