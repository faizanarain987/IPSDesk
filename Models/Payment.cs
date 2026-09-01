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
    
    public decimal Discount { get; set; } = 0;
    
    public decimal TotalCharge { get; set; } = 0;
    
    public decimal PackageCharges { get; set; } = 0;
    public decimal ConnectionCharges { get; set; } = 0;
    public decimal RouterCharges { get; set; } = 0;
    public decimal FibreCharges { get; set; } = 0;
    public decimal ComplainCharges { get; set; } = 0;
    public decimal OtherCharges { get; set; } = 0;

    public DateTime PaymentDate { get; set; } = DateTime.Now;
    
}
