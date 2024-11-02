using OperationService.ViewModels;
using OperationService.ViewModels.Request;

namespace OperationService.Repositories.Interfaces;

public interface IAccountRepository
{
  Task<AccountViewModel> CreateAccountAsync(AccountRequest accountRequest);
}