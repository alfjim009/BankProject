using Microsoft.IdentityModel.Tokens;

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

    public async Task<bool> UpdatePersonAsync(int personId, PersonUpdateRequest personRequest)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync();
        try
        {
            var person = await _dbContext.Persons.FindAsync(personId);
            if (person == null) return false;

            if (!person.Name.IsNullOrEmpty())
            {
                person.Name = personRequest.Name;
            }
            if (person.Age != 0)
            {
                person.Age = personRequest.Age;
            }
            if (person.Identificacion.IsNullOrEmpty())
            {
                person.Identificacion = personRequest.Identificacion;
            }
            if (person.Address.IsNullOrEmpty())
            {
                person.Address = personRequest.Address;
            }
            if (person.Phone.IsNullOrEmpty())
            {
                person.Phone = personRequest.Phone;
            }

            await _dbContext.SaveChangesAsync();
            await transaction.CommitAsync();

            return true;
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}