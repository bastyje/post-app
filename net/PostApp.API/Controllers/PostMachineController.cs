using Microsoft.AspNetCore.Mvc;
using PostApp.Application.Common.Models;
using PostApp.Application.PostMachines.Commands;
using PostApp.Application.PostMachines.Queries.GetAllPostMachines;
using PostApp.Application.PostMachines.Queries.GetPostMachine;

namespace PostApp.API.Controllers;

public class PostMachineController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PaginationRequest paginationRequest)
    {
        return new OkObjectResult(await Mediator.Send(new GetAllPostMachinesQuery(paginationRequest)));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return new OkObjectResult(await Mediator.Send(new GetPostMachineQuery(id)));
    }

    [HttpPost]
    public async Task<IActionResult> AddPostMachine([FromBody] CreatePostMachineCommand createPostMachineCommand)
    {
        return new OkObjectResult(await Mediator.Send(createPostMachineCommand));
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePostMachine([FromBody] UpdatePostMachineCommand updatePostMachineCommand)
    {
        return new OkObjectResult(await Mediator.Send(updatePostMachineCommand));
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeletePostMachine([FromBody] DeletePostMachineCommand deletePostMachineCommand)
    {
        return new OkObjectResult(await Mediator.Send(deletePostMachineCommand));
    }
}
