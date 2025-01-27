using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

using static EventApp.Modules.Events.Application.Events.GetEvent.GetEvent;

namespace EventApp.Modules.Events.Presentation.Events;
internal static class GetEvent
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("event/{id}", async (Guid id,
            ISender sender) =>
        {
           EventResponse @event= await sender.Send(new GetEventQuery(id));
            
            return @event is null ? Results.NotFound() : Results.Ok(@event);
        })
            .WithTags(Tags.Events);
    }
}

