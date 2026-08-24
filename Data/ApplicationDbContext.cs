using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IPSDesk.Models;

namespace IPSDesk.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Package> Packages { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    public DbSet<MonthlyPackageHistory> MonthlyPackageHistories { get; set; }
    public DbSet<Payment> Payments { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<ApplicationUser>()
            .HasQueryFilter(u => !u.IsDeleted);
        
        builder.Entity<Customer>()
            .HasQueryFilter(c => !c.IsDeleted);

        builder.Entity<Package>()
            .HasQueryFilter(p => !p.IsDeleted);

        builder.Entity<Payment>()
            .HasQueryFilter(p => !p.IsDeleted);

        builder.Entity<PaymentMethod>()
            .HasQueryFilter(p => !p.IsDeleted);

        builder.Entity<MonthlyPackageHistory>()
            .HasQueryFilter(m => !m.IsDeleted)
            .HasOne(m => m.Package)
            .WithMany()
            .HasForeignKey(m => m.PackageId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Customer>()
            .HasOne(c => c.CurrentPackage)
            .WithMany()
            .HasForeignKey(c => c.CurrentPackageId)
            .OnDelete(DeleteBehavior.Restrict);
            
        builder.Entity<Payment>()
            .HasOne(p => p.PaymentMethod)
            .WithMany()
            .HasForeignKey(p => p.PaymentMethodId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    public override int SaveChanges()
    {
        UpdateAuditFields();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateAuditFields();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void UpdateAuditFields()
    {
        var entries = ChangeTracker.Entries<AuditableEntity>();
        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTime.Now;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAt = DateTime.Now;
            }
        }
    }
}
