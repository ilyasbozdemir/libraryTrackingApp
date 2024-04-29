﻿using LibraryTrackingApp.Application.DataTransferObjects;
using LibraryTrackingApp.Application.Features.BookInventories.Commands.Requests;
using LibraryTrackingApp.Domain.Entities.Library;

namespace LibraryTrackingApp.Application.Features.BookInventories.Behaviors.Mapping;

public class BookMappingProfile : Profile
{
    public BookMappingProfile()
    {
        CreateMap<BookCatalog, BookDTO>().ReverseMap();
        CreateMap<BookCatalog, CreateBookCommandRequest>().ReverseMap();
        CreateMap<BookDTO, CreateBookCommandRequest>().ReverseMap();

        // lazım olan yerde burda map'leme yapılabilir.
    }
}