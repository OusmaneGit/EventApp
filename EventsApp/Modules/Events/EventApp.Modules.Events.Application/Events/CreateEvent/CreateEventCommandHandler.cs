using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventApp.Modules.Events.Application.Abstractions.Data;
using EventApp.Modules.Events.Domain.Events;
using MediatR;


namespace EventApp.Modules.Events.Application.Events.CreateEvent;
internal sealed class CreateEventCommandHandler(IEventRepository eventRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<CreateEventCommand, Guid>
{


    public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        var @event= Event.Create(request.Title,
            request.Description,
            request.Location, 
            request.StartsAtUtc,
            request.EndsAtUtc);

        
        eventRepository.Insert(@event);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return @event.Id;
    }


}
