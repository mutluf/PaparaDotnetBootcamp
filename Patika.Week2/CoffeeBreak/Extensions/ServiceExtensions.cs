using CoffeeBreak.Services.CoffeeServices;
using CoffeeBreak.Services.UserServices;

namespace CoffeeBreak.Extensions;

public static class ServiceExtensions
{
    public static void AddFakeServices(this IServiceCollection services, ConfigurationManager builderConfiguration)
    {
        services.AddScoped<ICoffeeService, FakeCoffeeService>();
        services.AddScoped<IUserService, FakeUserService>();
    }
}
