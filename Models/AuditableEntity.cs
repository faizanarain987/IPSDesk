namespace IPSDesk.Models;

public abstract class AuditableEntity
{
    public string? CreatedById { get; set; }
    public string? CreatedByName { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    public string? UpdatedById { get; set; }
    public string? UpdatedByName { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
    public bool IsDeleted { get; set; } = false;
}
