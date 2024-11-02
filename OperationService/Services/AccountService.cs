namespace OperationService.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;

    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public Task<AccountViewModel> CreateAccountAsync(AccountRequest accountRequest)
    {
        return _accountRepository.CreateAccountAsync(accountRequest);
    }
}