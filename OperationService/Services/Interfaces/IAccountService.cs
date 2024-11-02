using OperationService.ViewModels;
using OperationService.ViewModels.Request;

namespace OperationService.Services.Interfaces;

public interface IAccountService
{
  Task<AccountViewModel> CreateAccountAsync(AccountRequest accountRequest);
}