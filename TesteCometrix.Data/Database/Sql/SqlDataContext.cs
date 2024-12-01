using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class SqlDataContext : DbContext
{

    public SqlDataContext()
    {
    }

    public SqlDataContext(DbContextOptions<SqlDataContext> options) : base(options)
    {
    }

    internal static string? GetConnectionEnviroment()
    {
        return Environment.GetEnvironmentVariable("DefaultConnection") ?? Environment.GetEnvironmentVariable("DEFAULTCONNECTION");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../TesteCometrix.Server");
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
            var configuration = new ConfigurationBuilder()
                                    .SetBasePath(basePath)
                                    .AddJsonFile("appsettings.json")
                                    .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
                                    .Build();

            var connectionString = configuration.GetConnectionString("SqlConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlDataContext).Assembly);
    }


    public DbSet<PaisEntity> PaisEntity { get; set; }
    public DbSet<ClienteEntity> ClienteEntity { get; set; }
}
