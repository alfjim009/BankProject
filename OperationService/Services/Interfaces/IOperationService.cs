namespace OperationService.Services.Interfaces;

public interface IOperationService
{
    Task<OperationViewModel> CreateOperationAsync(OperationRequest operationRequest);
}