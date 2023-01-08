using AutoMapper;
using MediatR;
using PostApp.Application.Common.Enums;
using PostApp.Application.Common.Interfaces;
using PostApp.Application.Common.Models;

namespace PostApp.Application.Users.Queries.GetUserByUsername;

public class GetUserByUsernameQuery : IRequest<ServiceMessage<GetUserByUsernameModel>>
{
    public string Username { get; }

    public GetUserByUsernameQuery(string username)
    {
        Username = username;
    }
}

public class GetUserByUsernameQueryHandler : IRequestHandler<GetUserByUsernameQuery, ServiceMessage<GetUserByUsernameModel>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUserByUsernameQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ServiceMessage<GetUserByUsernameModel>> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
    {
        var serviceMessage = new ServiceMessage<GetUserByUsernameModel>();
        var user = _userRepository.GetByUsername(request.Username);
        if (user is null)
        {
            serviceMessage.ErrorMessages.Add(new ErrorMessage(
                $"User with username: '{request.Username}' was not found",
                ErrorTypeEnum.Error));
        }
        else
        {
            serviceMessage.Content = _mapper.Map<GetUserByUsernameModel>(user);
        }
        
        return serviceMessage;
    }
}