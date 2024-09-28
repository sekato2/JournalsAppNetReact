using Journals.Domain.Repositories;
using Journals.Infraestructure.Persistence;
using Journals.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Journals.Infraestructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("JournalDB");
        services.AddDbContext<JournalDbContext>(options => options.UseSqlServer(connectionString));

        services.AddScoped<IJournalRepository, JournalRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
    }
}
