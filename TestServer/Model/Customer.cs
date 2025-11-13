using System; 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 

namespace TestServer.Models;

public class Customer
{
    [Key]
    [StringLength(100)]
    public string Id { get; set; } = string.Empty;

    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [StringLength(100)]
    public string Email { get; set; } = string.Empty;

    [StringLength(15)]
    public string PhoneNumber { get; set; } = string.Empty;

    [StringLength(255)]
    public string Address { get; set; } = string.Empty;

    // Status is an enum; don't apply string-specific data annotations (e.g. StringLength)
    // which are intended for string properties and can confuse EF mapping.
    public CustomerStatus Status { get; set; } = CustomerStatus.Available;

    public enum CustomerStatus
    {
        Available,
        Unavailable,
    }
}
    