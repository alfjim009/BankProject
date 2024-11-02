namespace OperationService.Repositories.Interfaces;

public interface IAccountRepository
{
    Task<AccountViewModel> CreateAccountAsync(AccountRequest accountRequest);
}