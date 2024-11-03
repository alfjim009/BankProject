namespace OperationService.Services;

public class OperationService : IOperationService
{
    private readonly IOperationRepository _operationRepository;

    public OperationService(IOperationRepository operationRepository)
    {
        _operationRepository = operationRepository;
    }

    public Task<OperationViewModel> CreateOperationAsync(OperationRequest operationRequest)
    {
        return _operationRepository.CreateOperationAsync(operationRequest);
    }
}