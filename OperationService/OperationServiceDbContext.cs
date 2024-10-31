using Microsoft.EntityFrameworkCore;
using OperationService.Models;

namespace OperationService;

public class OperationServiceDbContext : DbContext
{
    public OperationServiceDbContext(DbContextOptions<OperationServiceDbContext> options) : base(options)
    {
    }

    public DbSet<Accounts> Accounts { get; set; }
    public DbSet<Operations> Operations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Operations>()
            .HasOne(o => o.Account)
            .WithMany(c => c.Operations)
            .HasForeignKey(o => o.AccountId);
    }
}