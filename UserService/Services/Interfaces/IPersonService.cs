namespace UserService.Services.Interfaces;

public interface IPersonService
{
    Task<string> CreatePersonAsync(PersonRequest personRequest);
}