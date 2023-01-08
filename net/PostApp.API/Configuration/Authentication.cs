using System.Text.Json;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace PostApp.API.Configuration;

public static class Authentication
{
    public static AuthenticationBuilder ConfigureAuthentication(this AuthenticationBuilder authenticationBuilder, IConfiguration configuration)
    {
        return authenticationBuilder.AddGoogle(googleOptions =>
        {
            googleOptions.ClientId = configuration["Authentication:Google:ClientId"];
            googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];
        });
    }

    public static AuthenticationBuilder ConfigureJwtBearer(this AuthenticationBuilder authenticationBuilder, IConfiguration configuration)
    {
        return authenticationBuilder.AddJwtBearer(options =>
        {
            options.Audience = configuration["Authentication:Audience"];
            options.Authority = configuration["Authentication:Authority"];
            options.Events = new JwtBearerEvents()
            {
                OnChallenge = context =>
                {
                    context.HandleResponse();
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    context.Response.ContentType = "application/json";

                    if (string.IsNullOrEmpty(context.Error))
                    {
                        context.Error = "invalid_token";
                    }

                    if (string.IsNullOrEmpty(context.ErrorDescription))
                    {
                        context.ErrorDescription = "This request requires valid JWT token to be provided";
                    }

                    return context.Response.WriteAsync(JsonSerializer.Serialize(new
                    {
                        error = context.Error,
                        error_description = context.ErrorDescription
                    }));
                }
            };
        });
    }
}