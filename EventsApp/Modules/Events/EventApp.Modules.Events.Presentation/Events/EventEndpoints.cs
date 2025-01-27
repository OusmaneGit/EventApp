using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;

namespace EventApp.Modules.Events.Presentation.Events;
public static class EventEndpoints
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        CreateEvent.MapEndpoint(app);
        GetEvent.MapEndpoint(app);
    }
}
