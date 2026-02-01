using Microsoft.Extensions.DependencyInjection;

namespace DomainDrivenDesign.Application;
public static class ApplicationRegistrar
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(opt =>
        {
            opt.RegisterServicesFromAssembly(typeof(ApplicationRegistrar).Assembly);

        });
        return services;
    }
}
