using Microsoft.AspNetCore.Mvc;
using PostApp.Application.Dictionaries.Queries.GetStatusList;

namespace PostApp.API.Controllers;

public class DictionaryController : BaseController
{
    [HttpGet("status")]
    public async Task<IActionResult> GetStatusDictionary(string username)
    {
        return new OkObjectResult(await Mediator.Send(new GetStatusListQuery()));
    }
}