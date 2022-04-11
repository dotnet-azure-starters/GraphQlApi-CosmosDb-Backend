using GraphQlCosmosDbStarter.Data;
using Microsoft.Azure.Cosmos;

namespace GraphQlCosmosDbStarter.Api.Extensions
{
    /// <summary>
    /// <see cref="IServiceCollection"/> extension methods add project services.
    /// </summary>
    /// <remarks>
    /// AddSingleton - Only one instance is ever created and returned.
    /// AddScoped - A new instance is created and returned for each request/response cycle.
    /// AddTransient - A new instance is created and returned each time.
    /// </remarks>
    internal static class ProjectServiceCollectionExtensions
    {
        public static IServiceCollection AddProjectMappers(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddProjectServices(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddProjectRepositories(this IServiceCollection services)
        {
            return services;
        }
        
        public static IServiceCollection AddCosmosDb(this IServiceCollection services, IConfiguration configuration)
        {
            var cosmosDbConnectionString = configuration.GetValue<string>("AppSettings:CosmosDbConnectionString");
            var cosmosDbName = configuration.GetValue<string>("AppSettings:CosmosDatabaseName");
            var containerName = "sites"; //TODO: in next iteration make this configurable to be able to query multiple containers

            var cosmosClient = new CosmosClient(cosmosDbConnectionString);
            services.AddSingleton<ICosmosDbService>(s => new CosmosDbService(cosmosClient, cosmosDbName, containerName));

            return services;
        }
    }
}
