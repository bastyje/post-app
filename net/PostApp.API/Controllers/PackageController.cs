using Microsoft.AspNetCore.Mvc;

namespace PostApp.API.Controllers;

public class PackageController : BaseController
{

    [HttpGet()]
    public IActionResult Get()
    {
        return new OkResult();
    }
}
