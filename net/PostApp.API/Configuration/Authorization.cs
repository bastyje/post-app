using Microsoft.AspNetCore.Authorization;
using PostApp.Application.Common;

namespace PostApp.API.Configuration;

public static class Authorization
{
    public static AuthorizationOptions ConfigureAuthorization(this AuthorizationOptions options)
    {
        options.AddPolicy(Permissions.Customer, policy => policy.RequireClaim("permission", Permissions.Customer));
        options.AddPolicy(Permissions.Employee, policy => policy.RequireClaim("permission", Permissions.Employee));
        return options;
    }
}