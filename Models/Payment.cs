using System.ComponentModel.DataAnnotations;

namespace IPSDesk.Models;

public class Payment : AuditableEntity
{
    public Guid Id { get; set; }
    
    public string ReceiptNumber { get; set; } = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
    
    public Guid CustomerId { get; set; }
    public Customer? Customer { get; set; }
    
    public Guid PaymentMethodId { get; set; }
    public PaymentMethod? PaymentMethod { get; set; }
    
    public string PaymentType { get; set; } = "Full Payment"; // Full, Partial, New Connection
    
    public decimal AmountCollected { get; set; }
    
    public string BillingMonth { get; set; } = string.Empty;
    
    public DateTime PaymentDate { get; set; } = DateTime.Now;
}
