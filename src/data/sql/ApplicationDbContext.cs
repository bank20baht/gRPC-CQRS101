using Microsoft.EntityFrameworkCore;
using GrpcCqrs101.Entity;

public class ApplicationDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; } = null!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Customer>().Property(t => t.created_at).HasDefaultValueSql("GETDATE()");

        modelBuilder.Entity<Customer>().Property(t => t.updated_at).HasDefaultValueSql("GETDATE()");

    }

    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries<Customer>())
        {
            if (entry.State == EntityState.Added)
            {
                if (entry.Entity.id == Guid.Empty)
                {
                    entry.Entity.id = Guid.NewGuid();
                }
                entry.Entity.created_at = DateTime.UtcNow;
                entry.Entity.updated_at = DateTime.UtcNow;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.updated_at = DateTime.UtcNow;
            }
        }

        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<Customer>())
        {
            if (entry.State == EntityState.Added)
            {
                if (entry.Entity.id == Guid.Empty)
                {
                    entry.Entity.id = Guid.NewGuid();
                }
                entry.Entity.created_at = DateTime.UtcNow;
                entry.Entity.updated_at = DateTime.UtcNow;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.updated_at = DateTime.UtcNow;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

}