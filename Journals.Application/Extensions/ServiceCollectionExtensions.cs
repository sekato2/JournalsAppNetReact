using Journals.Application.Journals;
using Journals.Application.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Journals.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IJournalsService, JournalsService>();
        services.AddScoped<IUsersService, UsersService>();
    }
}
