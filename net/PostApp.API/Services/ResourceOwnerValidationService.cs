using Duende.IdentityServer.Models;
using Duende.IdentityServer.Validation;
using MediatR;
using PostApp.Application.Users.Commands.VerifyPasswordHash;
using PostApp.Application.Users.Queries.GetUserForValidation;

namespace PostApp.API.Services;

public class ResourceOwnerValidationService : IResourceOwnerPasswordValidator
{
    private readonly IMediator _mediator;

    public ResourceOwnerValidationService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
    {
        var serviceMessage = await _mediator.Send(new GetUserForValidationQuery(context.UserName));
        if (serviceMessage.Success && await _mediator.Send(new VerifyPasswordHashCommand(serviceMessage.Content.PasswordHash, context.Password)))
        {
            context.Result = new GrantValidationResult(serviceMessage.Content.Id, GrantType.ResourceOwnerPassword);
        }
    }
}