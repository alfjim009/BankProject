namespace UserService.Services;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _personRepository;

    public PersonService(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public Task<string> CreatePersonAsync(PersonRequest personRequest)
    {
        return _personRepository.CreatePersonAsync(personRequest);
    }
}