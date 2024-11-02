using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using OperationService.Models;

namespace OperationService;

public class OperationServiceDbContext : DbContext
{
    public OperationServiceDbContext(DbContextOptions<OperationServiceDbContext> options) : base(options)
    {
        try
        {
            var dbCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;

            if (dbCreator != null)
            {
                if (!dbCreator.CanConnect())
                {
                    dbCreator.Create();
                }

                if (!dbCreator.HasTables())
                {
                    dbCreator.CreateTables();
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
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