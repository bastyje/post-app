using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PostApp.Application.Common;
using PostApp.Application.Common.Interfaces;
using PostApp.Application.Common.Models;
using PostApp.Application.Packages.Commands;
using PostApp.Application.Packages.Queries.GetAllByPostMachine;
using PostApp.Application.Packages.Queries.GetAllByReceiver;
using PostApp.Application.Packages.Queries.GetAllBySender;
using PostApp.Application.Packages.Queries.GetAllPackages;
using PostApp.Application.Packages.Queries.GetPackage;
using PostApp.Application.Packages.Queries.GetReadyToReceive;

namespace PostApp.API.Controllers;

[Authorize]
public class PackageController : BaseController
{
    private readonly ICurrentUserService _currentUserService;

    public PackageController(ICurrentUserService currentUserService)
    {
        _currentUserService = currentUserService;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPackage(int id)
    {
        return new OkObjectResult(await Mediator.Send(new GetPackageQuery(id)));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPackages([FromQuery] PaginationRequest paginationRequest)
    {
        return new OkObjectResult(await Mediator.Send(new GetAllPackagesQuery(paginationRequest)));
    }

    [HttpGet("senderId={senderId}")]
    public async Task<IActionResult> GetAllBySender(string senderId)
    {
        return new OkObjectResult(await Mediator.Send(new GetAllBySenderQuery(senderId)));
    }

    [HttpGet("receiverId={receiverId}")]
    public async Task<IActionResult> GetAllByReceiver(string receiverId)
    {
        return new OkObjectResult(await Mediator.Send(new GetAllByReceiverQuery(receiverId)));
    }

    [HttpGet("postMachineId={postMachineId}")]
    public async Task<IActionResult> GetAllByPostMachine(int postMachineId)
    {
        return new OkObjectResult(await Mediator.Send(new GetAllByPostMachineQuery(postMachineId)));
    }
    
    [HttpGet("my")]
    public async Task<IActionResult> GetMyReadyToReceive()
    {
        return new OkObjectResult(await Mediator.Send(new GetReadyToReceiveQuery(_currentUserService.UserId)));
    }

    [HttpPost]
    public async Task<IActionResult> AddPackage([FromBody] CreatePackageCommand createPackageCommand)
    {
        createPackageCommand.SenderId = _currentUserService.UserId;
        return new OkObjectResult(await Mediator.Send(createPackageCommand));
    }

    [HttpPut]
    [Authorize(Policy = Permissions.Employee)]
    public async Task<IActionResult> UpdatePackageStatus([FromBody] UpdatePackageStatusCommand updatePackageStatusCommand)
    {
        return new OkObjectResult(await Mediator.Send(updatePackageStatusCommand));
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> ReceivePackage(int id)
    {
        return new OkObjectResult(await Mediator.Send(new DeletePackageCommand(id)));
    }
}
