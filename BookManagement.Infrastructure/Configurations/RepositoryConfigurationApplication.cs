using BookManagement.Core.Repositories;
using BookManagement.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BookManagement.Infrastructure.Configurations;

public static class RepositoryConfigurationApplication
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IPublisherRepository, PublisherRepository>();

        return services;
    }
}