using Microsoft.Extensions.DependencyInjection;
using Store.Application.Interfaces;
using Store.Application.Repositories;
using Store.Data.Repositories;

namespace Store.Data;

public static class DataServicesExtensions
{
    public static IServiceCollection AddDataServices(this IServiceCollection services)
    {
        services.AddTransient<IClientsRepository, ClientsRepository>();
        services.AddTransient<IClientOrdersRepository, ClientOrdersRepository>();
        services.AddTransient<IOrderItemsRepository, OrderItemsRepository>();
        services.AddTransient<IProductCategoriesRepository, ProductCategoriesRepository>();
        services.AddTransient<IProductInfosRepository, ProductInfosRepository>();
        services.AddTransient<IProductSubCategoriesRepository, ProductSubCategoriesRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();

        return services;
    }
}