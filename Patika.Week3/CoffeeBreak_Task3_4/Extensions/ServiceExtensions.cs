using CoffeeBreak_Task3_4.Services.CoffeeServices;
using CoffeeBreak_Task3_4.Services.UserServices;

namespace CoffeeBreak_Task3_4.Extensions;

public static class ServiceExtensions
{
    public static void AddFakeServices(this IServiceCollection services, ConfigurationManager builderConfiguration)
    {
        services.AddScoped<ICoffeeService, FakeCoffeeService>();
        services.AddScoped<IUserService, FakeUserService>();
    }
}
