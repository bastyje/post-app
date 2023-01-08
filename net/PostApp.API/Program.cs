using Microsoft.AspNetCore.Authentication.JwtBearer;
using PostApp.API.Configuration;
using PostApp.API.Identity;
using PostApp.API.Services;
using PostApp.Application;
using PostApp.Application.Common.Interfaces;
using PostApp.Persistence;

const string corsPolicyName = "PostAppCorsPolicy";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

builder.Services 
    // add application layers
    .AddPersistence(builder.Configuration)
    .AddApplication()
    // add IdentityServer
    .ConfigureIdentityServer()
    // add authentication
    .AddAuthentication("Bearer")
    .AddJwtBearerConfiguration(builder.Configuration["Authority"]);

builder.Services.AddAuthorization(options => options.ConfigureAuthorization());


builder.Services.AddCors(options =>
{
    var urls = builder.Configuration
        .GetSection("Application:Urls")
        .GetChildren()
        .Select(x => x.Value)
        .ToArray();
    
    options.AddPolicy(corsPolicyName, builder => builder
        .WithOrigins(urls)
        .AllowAnyHeader()
        .AllowAnyMethod());
});

var app = builder.Build();

app.UseIdentityServer()
    .UseAuthentication()
    .UseAuthorization()
    .UseCors(corsPolicyName)
    .UseAuthorization();

app.MapControllers();

app.Run();
