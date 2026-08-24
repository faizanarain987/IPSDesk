using System.ComponentModel.DataAnnotations;

namespace IPSDesk.Models;

public class MonthlyPackageHistory : AuditableEntity
{
    public Guid Id { get; set; }
    
    public Guid CustomerId { get; set; }
    public Customer? Customer { get; set; }
    
    public Guid PackageId { get; set; }
    public Package? Package { get; set; }
    
    public string BillingMonth { get; set; } = string.Empty; // e.g., "August 2026"
    
    public decimal PackagePrice { get; set; }
    public decimal AmountPaid { get; set; }
    public decimal RemainingBalance { get; set; }
    
    public string PaymentStatus { get; set; } = "Unpaid"; // Paid, Partially Paid, Unpaid
    
    public DateTime RenewalDate { get; set; } = DateTime.Now;
}
