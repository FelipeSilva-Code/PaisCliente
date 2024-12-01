using Microsoft.Extensions.DependencyInjection;

public static class DomainStartup
{
    public static IServiceCollection DomainRegister(this IServiceCollection services)
    {
        services.AddScoped<IPaisDomain, PaisDomain>();
        services.AddScoped<IClienteDomain, ClienteDomain>();

        services.RepositoryRegister();
        return services;
    }
}

