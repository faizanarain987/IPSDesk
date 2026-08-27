using System.ComponentModel.DataAnnotations;

namespace IPSDesk.Models;

public class CompanySettings : AuditableEntity
{
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Company Name is required")]
    public string CompanyName { get; set; } = "Diamond Net";
    
    public string? Email { get; set; }
    
    public string? Phone { get; set; }
    
    public string? WhatsApp { get; set; }
    
    public string? Address { get; set; }
}
