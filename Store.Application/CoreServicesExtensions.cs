using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Store.Application.AutoMapper;
using Store.Application.Interfaces;
using Store.Application.Services;

namespace Store.Application;

public static class CoreServicesExtensions
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IProductService, ProductService>();

        // Automapper Configuration
        services.AddAutoMapper(typeof(CategoriesProfile));
        services.AddAutoMapper(typeof(OrderProfile));
        services.AddAutoMapper(typeof(ProductProfile));
        
        services.AddValidatorsFromAssembly(typeof(CoreServicesExtensions).GetTypeInfo().Assembly);

        return services;
    }
}