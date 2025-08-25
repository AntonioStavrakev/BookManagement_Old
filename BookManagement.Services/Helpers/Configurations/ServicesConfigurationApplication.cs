using System.Reflection;
using BookManagement.Services.Models.AuthorModels.Interfaces;
using BookManagement.Services.Services;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookManagement.Services.Helpers.Configurations
{
    public static class ServicesConfigurationApplication
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
    
            services.AddAutoMapper(assembly);
    
            services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(assembly));
    
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IPublisherService, PublisherService>();
            
    
            return services;
        }
    }
}