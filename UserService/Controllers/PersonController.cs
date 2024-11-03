namespace UserService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private readonly ILogger<PersonController> _logger;
    private readonly IPersonService _personService;

    public PersonController(ILogger<PersonController> logger, IPersonService personService)
    {
        _logger = logger;
        _personService = personService;
    }

    [HttpPost]
    [ProducesResponseType(200, Type = typeof(string))]
    [ProducesResponseType(404)]
    public async Task<ActionResult<string>> CreatePersonAsync([FromBody] PersonRequest personRequest)
    {
        var client = await _personService.CreatePersonAsync(personRequest);
        return Ok(client);
    }
}