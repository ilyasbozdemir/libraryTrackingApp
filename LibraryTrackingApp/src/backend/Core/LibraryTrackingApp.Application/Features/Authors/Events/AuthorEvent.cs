﻿using LibraryTrackingApp.Domain.Events;

namespace LibraryTrackingApp.Application.Features.Authors.Events;

public class AuthorEvent
    : BaseEvent
{
    public Guid AuthorId { get; set; }
    public RequestNotificationType RequestNotificationType { get; set; }
}
