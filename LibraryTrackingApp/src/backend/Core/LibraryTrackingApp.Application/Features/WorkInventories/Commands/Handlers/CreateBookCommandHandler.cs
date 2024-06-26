﻿using LibraryTrackingApp.Application.Features.WorkInventories.Commands.Requests;
using LibraryTrackingApp.Application.Features.WorkInventories.Commands.Responses;
using LibraryTrackingApp.Application.Interfaces.UnitOfWork;

namespace LibraryTrackingApp.Application.Features.WorkInventories.Commands.Handlers;

// book crud işlemleri tekrdan düzenelecektir.
public class CreateBookCommandHandler : IRequestHandler<CreateBookCommandRequest, CreateBookCommandResponse>
{
    private readonly IUnitOfWork<Guid> _unitOfWork;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public CreateBookCommandHandler(IUnitOfWork<Guid> unitOfWork, IMapper mapper, IMediator mediator)
    {
        _unitOfWork = unitOfWork;
        _mediator = mediator;
        _mapper = mapper;
    }


    // kitap olustururken stok miktarı da eklenecek

    public async Task<CreateBookCommandResponse> Handle(CreateBookCommandRequest request, CancellationToken cancellationToken)
    {

        try
        {
            var existingBook = await _unitOfWork.GetReadRepository<Domain.Entities.Library.WorkCatalog>()
                .ExistsAsync(b => b.ISBN == request.ISBN);

            if (existingBook)
            {
                return new()
                {
                    StatusCode = 409,
                    Success = false,
                    StateMessages = new string[] { "Bu ISBN numarasına sahip bir kitap zaten mevcut." }
                };
            }



            var newBook = _mapper.Map<Domain.Entities.Library.WorkCatalog>(request);
            newBook.Id = Guid.NewGuid();


            var writeRepository = _unitOfWork.GetWriteRepository<Domain.Entities.Library.WorkCatalog>();
            bool isAdded = await writeRepository.AddAsync(newBook);

            if (isAdded)
            {

                return new()
                {
                    StatusCode = 200,
                    Success = true,
                    StateMessages = new string[] { "Kitap başarıyla eklendi." },

                };
            }
            else
            {

                return new()
                {
                    StatusCode = 400,
                    Success = false,
                    StateMessages = new string[] { "Kitap eklenirken bir hata oluştu." }
                };
            }

        }
        catch (Exception ex)
        {
            return new()
            {
                StatusCode = 500,
                Success = false,
                StateMessages = new string[] { $"Bir hata oluştu: {ex.Message}" }
            };
        }
    }
}