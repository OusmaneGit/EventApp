using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventApp.Modules.Events.Application.Abstractions.Data;
using EventApp.Modules.Events.Domain.Events;
using Microsoft.EntityFrameworkCore;

namespace EventApp.Modules.Events.Infrastructure.Database;
public sealed class EventsDbContext(DbContextOptions<EventsDbContext> options) : DbContext(options), IUnitOfWork

{
    internal DbSet<Event> Events { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Events);
    }
}
