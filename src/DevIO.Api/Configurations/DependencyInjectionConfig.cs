using DevIO.Business.Interfaces;
using DevIO.Business.Notifications;
using DevIO.Data.Context;
using DevIO.Data.Repository;

namespace DevIO.Api.Configurations;

public static class DependencyInjectionConfig
{
    public static IServiceCollection ResolveDependencies(this IServiceCollection services)
    {
        // Data
        services.AddScoped<DevIODbContext>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ISupplierRepository, SupplierRepository>();

        // Business
        services.AddScoped<ISupplierRepository, SupplierRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<INotifier, Notifier>();

        return services;
    }
}
