namespace OperationService.Repositories;

public class OperationRepository : IOperationRepository
{
    private readonly OperationServiceDbContext _dbContext;

    public OperationRepository(OperationServiceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<OperationViewModel> CreateOperationAsync(OperationRequest operationRequest)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync();
        try
        {
            var operationViewModel = new OperationViewModel();

            var newOperation = new Operations()
            {
                Date = DateTime.Now,
                IsDeposit = operationRequest.IsDeposit,
                Value = operationRequest.Value,
                AccountId = 123123
            };

            _dbContext.Operations.Add(newOperation);

            await _dbContext.SaveChangesAsync();
            await transaction.CommitAsync();

            operationViewModel.Date = newOperation.Date;
            operationViewModel.IsDeposit = newOperation.IsDeposit;
            operationViewModel.Balance = 123123123;
            operationViewModel.Value = newOperation.Value;

            return operationViewModel;
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}