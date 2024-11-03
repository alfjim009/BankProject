namespace UserService.Services.Interfaces;

public interface IClientService
{
    Task<ClientViewModel> CreateClientAsync(ClientRequest clientRequest);
}