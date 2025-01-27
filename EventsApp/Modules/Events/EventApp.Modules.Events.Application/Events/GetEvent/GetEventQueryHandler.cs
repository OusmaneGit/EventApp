using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using EventApp.Modules.Events.Application.Abstractions.Data;
using EventApp.Modules.Events.Application.Events.GetEvent.GetEvent;
using MediatR;


namespace EventApp.Modules.Events.Application.Events.GetEvent;
internal sealed class GetEventQueryHandler(IDbConnectionFactory dbConnectionFactory)
        : IRequestHandler<GetEventQuery, EventResponse?>
    {
        public async Task<EventResponse?> Handle(GetEventQuery request, CancellationToken cancellationToken)
        {
            using IDbConnection connection = await dbConnectionFactory.OpenConnectionAsync();
            const string sql =
                $"""
                   SELECT 
                   id AS {nameof(EventResponse.Id)},
                   title AS {nameof(EventResponse.Title)},
                   description AS {nameof(EventResponse.Description)},
                   location AS {nameof(EventResponse.Location)},
                   starts_at_utc AS {nameof(EventResponse.StartsAtUtc)},
                   ends_at_utc AS {nameof(EventResponse.EndsAtUtc)}
                """;
            EventResponse? @event = await connection.QuerySingleOrDefaultAsync(sql, request);
            return @event;
        }
    }



