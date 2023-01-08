using MediatR;
using PostApp.Application.Common;
using PostApp.Application.Common.Enums;
using PostApp.Application.Common.Interfaces;
using PostApp.Application.Common.Models;

namespace PostApp.Application.Users.Queries.GetUserPermissions;

public class GetUserPermissionsQuery : IRequest<ServiceMessage<List<string>>>
{
    public GetUserPermissionsQuery(string username)
    {
        Username = username;
    }
    
    public string Username { get; }
}

public class GetUserPermissionsQueryHandler : IRequestHandler<GetUserPermissionsQuery, ServiceMessage<List<string>>>
{
    private readonly IUserRepository _userRepository;

    public GetUserPermissionsQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<ServiceMessage<List<string>>> Handle(GetUserPermissionsQuery request, CancellationToken cancellationToken)
    {
        var serviceMessage = new ServiceMessage<List<string>> { Content = new List<string>() };
        var user = await _userRepository.GetAsync(request.Username, cancellationToken);
        if (user != null)
        {
            serviceMessage.Content.Add(user.IsEmployee ? Permissions.Employee : Permissions.Customer);
        }
        else
        {
            serviceMessage.ErrorMessages.Add(new ErrorMessage("User does not exist", ErrorTypeEnum.Error));
        }

        return serviceMessage;
    }
}
