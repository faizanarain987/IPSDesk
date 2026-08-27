using System.ComponentModel.DataAnnotations;

namespace IPSDesk.Models;

public class PaymentItem : AuditableEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required]
    public Guid PaymentId { get; set; }
    public Payment? Payment { get; set; }
    
    [Required]
    public string Description { get; set; } = string.Empty;
    
    public decimal Amount { get; set; }
}
