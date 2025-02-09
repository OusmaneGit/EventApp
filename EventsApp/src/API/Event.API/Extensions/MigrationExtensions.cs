﻿using EventApp.Modules.Events.Api.Database;
using EventApp.Modules.Events.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
namespace EventApp.API.Extensions;

internal static  class MigrationExtensions
{
    internal static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope=app.ApplicationServices.CreateScope();
        ApplyMigration<EventsDbContext>(scope);
    }
    private static void ApplyMigration<TDbContext>(IServiceScope scope)
        where TDbContext : DbContext
    {
        using TDbContext context= scope.ServiceProvider.GetRequiredService<TDbContext>();
        context.Database.Migrate();
    }
}
