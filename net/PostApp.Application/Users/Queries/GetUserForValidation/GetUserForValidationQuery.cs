using AutoMapper;
using MediatR;
using PostApp.Application.Common.Enums;
using PostApp.Application.Common.Interfaces;
using PostApp.Application.Common.Models;
using PostApp.Application.Users.Queries.GetUserForValidation;

namespace PostApp.Application.Users.Queries.GetUserForValidation;

public class GetUserForValidationQuery : IRequest<ServiceMessage<GetUserForValidationModel>>
{
    public string Username { get; }

    public GetUserForValidationQuery(string username)
    {
        Username = username;
    }
}

public class GetUserForValidationQueryHandler : IRequestHandler<GetUserForValidationQuery, ServiceMessage<GetUserForValidationModel>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUserForValidationQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ServiceMessage<GetUserForValidationModel>> Handle(GetUserForValidationQuery request, CancellationToken cancellationToken)
    {
        var serviceMessage = new ServiceMessage<GetUserForValidationModel>();
        var user = _userRepository.GetByUsername(request.Username);
        if (user is null)
        {
            serviceMessage.ErrorMessages.Add(new ErrorMessage(
                $"User with username: '{request.Username}' was not found",
                ErrorTypeEnum.Error));
        }
        else
        {
            serviceMessage.Content = _mapper.Map<GetUserForValidationModel>(user);
        }
        
        return serviceMessage;
    }
}