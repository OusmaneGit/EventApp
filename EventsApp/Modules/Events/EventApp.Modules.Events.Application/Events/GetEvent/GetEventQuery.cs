using EventApp.Modules.Events.Application.Events.GetEvent.GetEvent;
using MediatR;


namespace EventApp.Modules.Events.Application.Events.GetEvent;

public sealed record GetEventQuery(Guid EventId) :
        IRequest<EventResponse?>;



