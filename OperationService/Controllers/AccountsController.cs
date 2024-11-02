using Microsoft.AspNetCore.Mvc;
using OperationService.Services.Interfaces;
using OperationService.ViewModels;
using OperationService.ViewModels.Request;

namespace OperationService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountsController : ControllerBase
{
    private readonly ILogger<AccountsController> _logger;
    private readonly IAccountService _accountService;

    public AccountsController(ILogger<AccountsController> logger, IAccountService accountService)
    {
        _logger = logger;
        _accountService = accountService;
    }


    [HttpPost]
    [ProducesResponseType(200, Type = typeof(AccountViewModel))]
    [ProducesResponseType(404)]
    public async Task<ActionResult<AccountViewModel>> CreateClientAsync([FromBody] AccountRequest accountRequest)
    {
        var client = await _accountService.CreateAccountAsync(accountRequest);
        return Ok(client);
    }
}