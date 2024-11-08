﻿namespace OperationService.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly OperationServiceDbContext _dbContext;

    public AccountRepository(OperationServiceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<AccountViewModel> CreateAccountAsync(AccountRequest accountRequest)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync();
        try
        {
            var accountViewModel = new AccountViewModel();

            var newAccount = new Accounts()
            {
                AccountNumber = 184188,
                AccountType = accountRequest.AccountType,
                Balance = accountRequest.OpeningBalance,
                Status = true,
                ClientId = accountRequest.ClientId
            };

            _dbContext.Accounts.Add(newAccount);

            await _dbContext.SaveChangesAsync();
            await transaction.CommitAsync();

            accountViewModel.AccountNumber = newAccount.AccountNumber;
            accountViewModel.AccountType = newAccount.AccountType;
            accountViewModel.ClientId = newAccount.ClientId;
            accountViewModel.OpeningBalance = newAccount.Balance;
            accountViewModel.Status = newAccount.Status;

            return accountViewModel;
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}