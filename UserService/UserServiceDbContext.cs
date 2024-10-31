using Microsoft.EntityFrameworkCore;
using UserService.Models;

namespace UserService;

public class UserServiceDbContext : DbContext
{
    public UserServiceDbContext(DbContextOptions<UserServiceDbContext> options) : base(options)
    {
    }

    public DbSet<Persons> Persons { get; set; }
    public DbSet<Clients> Clients { get; set; }
}