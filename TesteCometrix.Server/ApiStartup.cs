
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;

public static class ApiStartup
{
    public static IServiceCollection ApiRegister(this WebApplicationBuilder webApplicationBuilder )
    {
        IServiceCollection services = webApplicationBuilder.Services;
        services.DomainRegister();

        return services;
    }
}
