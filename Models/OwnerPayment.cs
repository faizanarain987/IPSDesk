using System.ComponentModel.DataAnnotations;

namespace IPSDesk.Models;

public class OwnerPayment : AuditableEntity
{
    public Guid Id { get; set; }
    
    [Required]
    public string EmployeeId { get; set; } = string.Empty;
    public ApplicationUser? Employee { get; set; }

    [Required]
    public decimal Amount { get; set; }
    
    public DateTime PaymentDate { get; set; } = DateTime.Now;
    
    public DateTime DateRangeStart { get; set; }
    public DateTime DateRangeEnd { get; set; }
    
    public decimal TotalCollectionAtTime { get; set; }
    
    public decimal PreviousBalance { get; set; }
    public decimal RemainingBalance { get; set; }
    
    public string? Notes { get; set; }
}
