using System.ComponentModel.DataAnnotations;

namespace IPSDesk.Models;

public class MonthlyPackageHistory : AuditableEntity
{
    public Guid Id { get; set; }
    
    public Guid CustomerId { get; set; }
    public Customer? Customer { get; set; }
    
    public Guid PackageId { get; set; }
    public Package? Package { get; set; }
    
    public decimal Discount { get; set; }
    
    public decimal PackagePrice { get; set; }
    public decimal AmountPaid { get; set; }
    public decimal RemainingBalance { get; set; }
    
    public DateTime RenewalDate { get; set; } = DateTime.Now;
}
