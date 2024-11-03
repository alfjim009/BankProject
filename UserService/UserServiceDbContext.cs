using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using UserService.Models;

namespace UserService;

public class UserServiceDbContext : DbContext
{
    public UserServiceDbContext(DbContextOptions<UserServiceDbContext> options) : base(options)
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
    public DbSet<Clients> Clients { get; set; }
    public DbSet<Persons> Persons { get; set; }
}