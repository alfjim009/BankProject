namespace UserService.Repositories.Interfaces;

public interface IClientRepository
{
    Task<ClientViewModel> CreateClientAsync(ClientRequest clientRequest);
}