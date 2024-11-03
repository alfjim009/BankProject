namespace UserService.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public Task<ClientViewModel> CreateClientAsync(ClientRequest clientRequest)
    {
        return _clientRepository.CreateClientAsync(clientRequest);
    }
}