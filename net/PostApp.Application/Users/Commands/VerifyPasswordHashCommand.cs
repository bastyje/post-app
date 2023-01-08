using System.Security.Cryptography;
using MediatR;

namespace PostApp.Application.Users.Commands.VerifyPasswordHash;

public class VerifyPasswordHashCommand : IRequest<bool>
{
    public VerifyPasswordHashCommand(string passwordHash, string enteredPassword)
    {
        PasswordHash = passwordHash;
        EnteredPassword = enteredPassword;
    }
    
    public string PasswordHash { get; }
    public string EnteredPassword { get; }
}

public class VerifyPasswordHashCommandHandler : IRequestHandler<VerifyPasswordHashCommand, bool>
{
    public Task<bool> Handle(VerifyPasswordHashCommand request, CancellationToken cancellationToken)
    {
        var hashBytes = Convert.FromBase64String(request.PasswordHash);
        var salt = new byte[HashingConstraints.SaltLength];
        Array.Copy(hashBytes, 0, salt, 0, HashingConstraints.SaltLength);
        var pbkdf2 = new Rfc2898DeriveBytes(request.EnteredPassword, salt, HashingConstraints.Iterations);
        var hash = pbkdf2.GetBytes(HashingConstraints.HashLength);

        var verified = true;
        for (var i = 0; i < HashingConstraints.HashLength; i++)
            if (hashBytes[i + HashingConstraints.SaltLength] != hash[i])
                verified = false;
        
        return Task.FromResult(verified);
    }
}