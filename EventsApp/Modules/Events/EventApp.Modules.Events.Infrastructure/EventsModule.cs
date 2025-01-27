using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventApp.Modules.Events.Application;
using EventApp.Modules.Events.Application.Abstractions.Data;
using EventApp.Modules.Events.Application.Events;
using EventApp.Modules.Events.Domain.Events;
using EventApp.Modules.Events.Infrastructure.Data;
using EventApp.Modules.Events.Infrastructure.Database;
using EventApp.Modules.Events.Infrastructure.Events;
using EventApp.Modules.Events.Presentation.Events;
using FluentValidation;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Npgsql;

namespace EventApp.Modules.Events.Infrastructure;
public static class EventsModule
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        EventEndpoints.MapEndpoint(app);
    }
    public static IServiceCollection AddEventsModule(this
        IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Application.AssemblyReference.Assembly);
        });
        services.AddValidatorsFromAssembly(Application.AssemblyReference.Assembly, includeInternalTypes:true);
        services.AddInfrastructure(configuration);
        return services;
    }

    private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        string databaseConnectionString = configuration.GetConnectionString("Database");

        NpgsqlDataSource npgDatasource = new NpgsqlDataSourceBuilder(databaseConnectionString).Build();
        services.TryAddSingleton(npgDatasource);

        services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
        services.AddDbContext<EventsDbContext>(options =>
        options.UseNpgsql(databaseConnectionString,
        npgsqlOptions => npgsqlOptions.MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Events))
        .UseSnakeCaseNamingConvention());
        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<IUnitOfWork>(
            sp => sp.GetRequiredService<EventsDbContext>());
       
    }
    }
