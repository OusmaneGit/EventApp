﻿namespace EventApp.Modules.Events.Application.Events.GetEvent.GetEvent;

public sealed record EventResponse(Guid Id,
    string Title,
    string Description,
    string Location,
    DateTime StartsAtUtc,
    DateTime? EndsAtUtc);

