using Duende.IdentityServer.Validation;

namespace PostApp.API.Identity;

public class ResourceOwnerValidator : IResourceOwnerPasswordValidator
{
    public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
    {
        context.Result.IsError = false;
        return Task.CompletedTask;
    }
}