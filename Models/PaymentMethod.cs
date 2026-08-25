using System.ComponentModel.DataAnnotations;

namespace IPSDesk.Models;

public class PaymentMethod : AuditableEntity
{
    public Guid Id { get; set; }
    
    [Required]
    public string Name { get; set; } = string.Empty; // Cash, Bank Transfer, etc.
    
    public bool IsActive { get; set; } = true;
    
    public bool IsDefault { get; set; } = false;
}
