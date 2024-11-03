namespace UserService.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly UserServiceDbContext _dbContext;

    public ClientRepository(UserServiceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ClientViewModel> CreateClientAsync(ClientRequest clientRequest)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync();
        try
        {
            var clientViewModel = new ClientViewModel();
            var newAccount = new Clients()
            {
                Name = clientRequest.Name,
                Gender = clientRequest.Gender,
                Age = clientRequest.Age,
                Identificacion = clientRequest.Identificacion,
                Address = clientRequest.Address,
                Phone = clientRequest.Phone,
                Status = true,
                Password = clientRequest.Password
            };

            _dbContext.Clients.Add(newAccount);

            await _dbContext.SaveChangesAsync();
            await transaction.CommitAsync();

            clientViewModel.InitialAccount = 123456;
            clientViewModel.InitialAccountType = "asdasdas";

            return clientViewModel;
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}