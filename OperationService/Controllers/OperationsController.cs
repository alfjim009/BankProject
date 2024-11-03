namespace OperationService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OperationsController : ControllerBase
{
    private readonly ILogger<OperationsController> _logger;
    private readonly IOperationService _operationService;

    public OperationsController(ILogger<OperationsController> logger, IOperationService operationService)
    {
        _logger = logger;
        _operationService = operationService;
    }

    [HttpPost]
    [ProducesResponseType(200, Type = typeof(OperationViewModel))]
    [ProducesResponseType(404)]
    public async Task<ActionResult<OperationViewModel>> CreateOperationAsync([FromBody] OperationRequest operationRequest)
    {
        var client = await _operationService.CreateOperationAsync(operationRequest);
        return Ok(client);
    }
}