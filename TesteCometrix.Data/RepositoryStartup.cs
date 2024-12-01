using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
public static class RepositoryStartup
{
    public static IServiceCollection RepositoryRegister(this IServiceCollection services)
    {
        services.AddScoped<IPaisRepository, PaisRepository>();
        services.AddScoped<IClienteRepository, ClienteRepository>();

        services.AddDbContext<SqlDataContext>((service, options) =>
        {
            var configuration = service.GetRequiredService<IConfiguration>();
            var connectionName = "SqlConnection";
            var defaultConnection = SqlDataContext.GetConnectionEnviroment() ?? configuration.GetConnectionString(connectionName);
            options.UseSqlServer(defaultConnection);
        });

        return services;
    }

}

