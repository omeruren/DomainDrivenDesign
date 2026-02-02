using DomainDrivenDesign.Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DomainDrivenDesign.Application;
public static class ApplicationRegistrar
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(opt =>
        {
            opt.RegisterServicesFromAssemblies(typeof(ApplicationRegistrar).Assembly, typeof(BaseEntity).Assembly);

        });
        return services;
    }
}
