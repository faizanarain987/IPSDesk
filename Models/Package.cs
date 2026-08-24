using System.ComponentModel.DataAnnotations;

namespace IPSDesk.Models;

public class Package : AuditableEntity
{
    public Guid Id { get; set; }
    
    [Required]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    public string Speed { get; set; } = string.Empty;
    
    [Required]
    [Range(0, 100000)]
    public decimal MonthlyPrice { get; set; }
    
    public string Description { get; set; } = string.Empty;
    
    public bool IsActive { get; set; } = true;
}
