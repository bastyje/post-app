using System.Security.AccessControl;
using MediatR;
using PostApp.Application.Common.Enums;
using PostApp.Application.Common.Interfaces;
using PostApp.Application.Common.Models;
using PostApp.Domain.Entities;
using PostApp.Domain.Enums;

namespace PostApp.Application.PostMachines.Commands;

public class CreatePostMachineCommand : IRequest<ServiceMessage>
{
    public string Name { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string PreciseLocation { get; set; }
}

public class CreatePostMachineCommandHandler : IRequestHandler<CreatePostMachineCommand, ServiceMessage>
{
    private readonly IPostMachineRepository _postMachineRepository;

    public CreatePostMachineCommandHandler(IPostMachineRepository postMachineRepository)
    {
        _postMachineRepository = postMachineRepository;
    }

    public async Task<ServiceMessage> Handle(CreatePostMachineCommand request, CancellationToken cancellationToken)
    {
        var serviceMessage = new ServiceMessage();

        if (_postMachineRepository.GetPostMachineByName(request.Name) is null)
        {
            _postMachineRepository.Add(new PostMachine
            {
                Name = request.Name,
                City = request.City,
                Country = request.Country,
                Number = request.Number,
                PostalCode = request.PostalCode,
                PreciseLocation = request.PreciseLocation,
                Street = request.Street
            });

            var saveResult = await _postMachineRepository.SaveChangesAsync(cancellationToken);

            if (saveResult != 1)
            {
                serviceMessage.ErrorMessages.Add(new ErrorMessage("Unable to save changes", ErrorTypeEnum.Error));
            }            
        }
        else
        {
            serviceMessage.ErrorMessages.Add(new ErrorMessage("Post machine with the same name exists", ErrorTypeEnum.Error));
        }

        return serviceMessage;
    }
}