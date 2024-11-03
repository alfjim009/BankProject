namespace OperationService.Repositories.Interfaces;

public interface IOperationRepository
{
    Task<OperationViewModel> CreateOperationAsync(OperationRequest operationRequest);
}