﻿namespace LibraryTrackingApp.Application.DTOs;

public record CreateLibraryBranchDTO : BaseAuditableDTO
{
    public string Name { get; init; }
    public string Address { get; init; } 
    public string PhoneNumber { get; init; } 
    public string Description { get; init; }
}