using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventApp.Modules.Events.Domain.Events;
using EventApp.Modules.Events.Infrastructure.Database;

namespace EventApp.Modules.Events.Infrastructure.Events;
internal sealed class EventRepository(EventsDbContext context) : IEventRepository
{
    public void Insert(Event @event)
    {
       context.Events.Add(@event);
    }
}
