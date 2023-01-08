using System.Security.Cryptography;
using MediatR;
using PostApp.Application.Common.Enums;
using PostApp.Application.Common.Interfaces;
using PostApp.Application.Common.Models;
using PostApp.Application.Users.Queries.GetUserByUsername;
using PostApp.Domain.Entities;

namespace PostApp.Application.Users.Commands.VerifyPasswordHash;

public class RegisterUserCommand : IRequest<ServiceMessage>
{
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public bool IsEmployee { get; set; }
}

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, ServiceMessage>
{
    private readonly IMediator _mediator;
    private readonly IUserRepository _userRepository;

    public RegisterUserCommandHandler(IMediator mediator, IUserRepository userRepository)
    {
        _mediator = mediator;
        _userRepository = userRepository;
    }
    
    public async Task<ServiceMessage> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var serviceMessage = Validate(request);
        
        var user = await _mediator.Send(new GetUserByUsernameQuery(request.Username));
        if (!user.Success)
        {
            _userRepository.Add(new ApplicationUser
            {
                Id = request.Username,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PasswordHash = HashPassword(request.Password),
                IsEmployee = request.IsEmployee
            });
            _userRepository.SaveChangesAsync(cancellationToken);
        }
        else
        {
            serviceMessage.ErrorMessages.Add(new ErrorMessage(
                $"User with username {request.Username} already exists",
                ErrorTypeEnum.Error));
        }

        return serviceMessage;
    }
    
    private static string HashPassword(string password)
    {
        var salt = new byte[HashingConstraints.SaltLength];
        new RNGCryptoServiceProvider().GetBytes(salt);
        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, HashingConstraints.Iterations);
        var hash = pbkdf2.GetBytes(HashingConstraints.HashLength);
        var hashBytes = new byte[HashingConstraints.SaltLength + HashingConstraints.HashLength];
        Array.Copy(salt, 0, hashBytes, 0, HashingConstraints.SaltLength);
        Array.Copy(hash, 0, hashBytes, HashingConstraints.SaltLength,  HashingConstraints.HashLength);
        return Convert.ToBase64String(hashBytes);
    }

    public ServiceMessage Validate(RegisterUserCommand registerUserCommand)
    {
        var serviceMessage = new ServiceMessage();

        if (registerUserCommand.Username == string.Empty)
        {
            serviceMessage.ErrorMessages.Add(new ErrorMessage("Username cannot be empty", ErrorTypeEnum.Error));
        }
        
        if (registerUserCommand.Password == string.Empty)
        {
            serviceMessage.ErrorMessages.Add(new ErrorMessage("Password cannot be empty", ErrorTypeEnum.Error));
        }
        
        if (registerUserCommand.FirstName == string.Empty)
        {
            serviceMessage.ErrorMessages.Add(new ErrorMessage("First name cannot be empty", ErrorTypeEnum.Error));
        }
        
        if (registerUserCommand.LastName == string.Empty)
        {
            serviceMessage.ErrorMessages.Add(new ErrorMessage("Last name cannot be empty", ErrorTypeEnum.Error));
        }
        
        return serviceMessage;
    }
}