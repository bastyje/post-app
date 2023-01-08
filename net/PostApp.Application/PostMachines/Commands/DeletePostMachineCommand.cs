using System.Security.AccessControl;
using MediatR;
using PostApp.Application.Common.Enums;
using PostApp.Application.Common.Interfaces;
using PostApp.Application.Common.Models;
using PostApp.Domain.Entities;
using PostApp.Domain.Enums;

namespace PostApp.Application.PostMachines.Commands;

public class DeletePostMachineCommand : IRequest<ServiceMessage>
{
    public int Id { get; set; }
}

public class DeletePostMachineCommandHandler : IRequestHandler<DeletePostMachineCommand, ServiceMessage>
{
    private readonly IPostMachineRepository _postMachineRepository;

    public DeletePostMachineCommandHandler(IPostMachineRepository postMachineRepository)
    {
        _postMachineRepository = postMachineRepository;
    }

    public async Task<ServiceMessage> Handle(DeletePostMachineCommand request, CancellationToken cancellationToken)
    {
        var serviceMessage = new ServiceMessage();
        
        var postMachine =  await _postMachineRepository.GetAsync(request.Id, cancellationToken);
        if (postMachine is null)
        {
            serviceMessage.ErrorMessages.Add(new ErrorMessage($"Unable to find post machine with id == {request.Id}", ErrorTypeEnum.Error));
            return serviceMessage;
        }

        _postMachineRepository.Delete(postMachine);
        var saveResult = await _postMachineRepository.SaveChangesAsync(cancellationToken);

        if (saveResult != 1)
        {
            serviceMessage.ErrorMessages.Add(new ErrorMessage("Unable to save changes", ErrorTypeEnum.Error));
        }

        return serviceMessage;
    }
}