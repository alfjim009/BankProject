namespace UserService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly ILogger<ClientsController> _logger;
    private readonly IClientService _clientService;

    public ClientsController(ILogger<ClientsController> logger, IClientService clientService)
    {
        _logger = logger;
        _clientService = clientService;
    }

    [HttpPost]
    [ProducesResponseType(200, Type = typeof(ClientViewModel))]
    [ProducesResponseType(404)]
    public async Task<ActionResult<ClientViewModel>> CreateClientAsync([FromBody] ClientRequest clientRequest)
    {
        var client = await _clientService.CreateClientAsync(clientRequest);
        return Ok(client);
    }
}