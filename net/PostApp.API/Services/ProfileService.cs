using System.Security.Claims;
using System.Text.Json;
using Duende.IdentityServer.Extensions;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using MediatR;
using PostApp.Application.Users.Queries.GetUserPermissions;

namespace PostApp.API.Services;

public class ProfileService : IProfileService
{
    private readonly IMediator _mediator;

    public ProfileService(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public async Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        var permissions = await _mediator.Send(new GetUserPermissionsQuery(context.Subject.GetSubjectId()));
        var permissionClaims = permissions.Content
            .Select(c => new Claim("permission", c))
            .ToList();
        context.IssuedClaims = permissionClaims;
    }

    public Task IsActiveAsync(IsActiveContext context)
    {
        context.IsActive = true; //_mediator.Send(new GetUser);
        
        return Task.CompletedTask;
    }
}