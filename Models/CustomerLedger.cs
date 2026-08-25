using System.ComponentModel.DataAnnotations;

namespace IPSDesk.Models;

public class CustomerLedger : AuditableEntity
{
    public Guid Id { get; set; }
    
    [Required]
    public Guid CustomerId { get; set; }
    public Customer? Customer { get; set; }
    
    public DateTime TransactionDate { get; set; } = DateTime.Now;
    
    [Required]
    public string Description { get; set; } = string.Empty;
    
    public decimal Debit { get; set; }
    
    public decimal Credit { get; set; }
    
    public decimal Balance { get; set; }
}
