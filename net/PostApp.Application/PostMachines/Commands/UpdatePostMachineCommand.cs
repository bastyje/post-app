using MediatR;
using PostApp.Application.Common.Enums;
using PostApp.Application.Common.Interfaces;
using PostApp.Application.Common.Models;
using PostApp.Domain.Entities;
using PostApp.Domain.Enums;

namespace PostApp.Application.PostMachines.Commands;

public class UpdatePostMachineCommand : IRequest<ServiceMessage>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string PreciseLocation { get; set; }
}

public class UpdatePostMachineCommandHandler : IRequestHandler<UpdatePostMachineCommand, ServiceMessage>
{
    private readonly IPostMachineRepository _postMachineRepository;

    public UpdatePostMachineCommandHandler(IPostMachineRepository postMachineRepository)
    {
        _postMachineRepository = postMachineRepository;
    }

    public async Task<ServiceMessage> Handle(UpdatePostMachineCommand request, CancellationToken cancellationToken)
    {
        var serviceMessage = new ServiceMessage();

        var postMachine =  await _postMachineRepository.GetAsync(request.Id, cancellationToken);
        
        if (postMachine is null)
        {
            serviceMessage.ErrorMessages.Add(new ErrorMessage($"Unable to find post machine with id == {request.Id}", ErrorTypeEnum.Error));
            return serviceMessage;
        }
        
        postMachine.Name = request.Name;
        postMachine.City = request.City;
        postMachine.Country = request.Country;
        postMachine.Number = request.Number;
        postMachine.PostalCode = request.PostalCode;
        postMachine.PreciseLocation = request.PreciseLocation;
        postMachine.Street = request.Street;

        _postMachineRepository.Update(postMachine);

        var saveResult = await _postMachineRepository.SaveChangesAsync(cancellationToken);

        if (saveResult != 1)
        {
            serviceMessage.ErrorMessages.Add(new ErrorMessage("Unable to save changes", ErrorTypeEnum.Error));
        }

        return serviceMessage;
    }
}