namespace OperationService.Services.Interfaces;

public interface IAccountService
{
    Task<AccountViewModel> CreateAccountAsync(AccountRequest accountRequest);
}