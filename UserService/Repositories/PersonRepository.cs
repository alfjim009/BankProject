namespace UserService.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly UserServiceDbContext _dbContext;

    public PersonRepository(UserServiceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<string> CreatePersonAsync(PersonRequest personRequest)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync();
        try
        {
            var newPerson = new Persons()
            {
                Name = personRequest.Name,
                Gender = personRequest.Gender,
                Age = personRequest.Age,
                Identificacion = personRequest.Identificacion,
                Address = personRequest.Address,
                Phone = personRequest.Phone
            };

            _dbContext.Persons.Add(newPerson);

            await _dbContext.SaveChangesAsync();
            await transaction.CommitAsync();

            return "Person Created";
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}