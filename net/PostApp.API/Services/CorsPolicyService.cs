using Duende.IdentityServer.Services;

public class CorsPolicyService : ICorsPolicyService
{
    public Task<bool> IsOriginAllowedAsync(string origin)
    {
        return Task.FromResult(true);
    }
}