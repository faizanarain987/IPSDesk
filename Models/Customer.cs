using System.ComponentModel.DataAnnotations;

namespace IPSDesk.Models;

public class Customer : AuditableEntity
{
    public Guid Id { get; set; }
    
    [Required]
    public string ConnectionId { get; set; } = string.Empty;
    
    [Required]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    public string Phone { get; set; } = string.Empty;
    public string WhatsApp { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Address { get; set; } = string.Empty;
    
    [Required]
    public string Cnic { get; set; } = string.Empty;
    
    public bool IsActive { get; set; } = true;
    
    public DateTime ConnectionDate { get; set; } = DateTime.Now;
    
    public decimal CurrentBalance { get; set; } = 0;
    
    // Relationships
    [Required(ErrorMessage = "Please select a package")]
    public Guid? CurrentPackageId { get; set; }
    public Package? CurrentPackage { get; set; }
    
    public ICollection<MonthlyPackageHistory> MonthlyHistory { get; set; } = new List<MonthlyPackageHistory>();
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    public ICollection<CustomerLedger> Ledgers { get; set; } = new List<CustomerLedger>();
}
