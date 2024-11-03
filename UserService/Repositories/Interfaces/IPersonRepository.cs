namespace UserService.Repositories.Interfaces;

public interface IPersonRepository
{
    Task<string> CreatePersonAsync(PersonRequest personRequest);
}