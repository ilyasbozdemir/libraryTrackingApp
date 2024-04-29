﻿namespace LibraryTrackingApp.Domain.Entities.Library;

public class BookCatalog : BaseEntity<Guid>, IAuditable<Guid>
{
    public Guid Id { get; set; }
    public Guid GenreId { get; set; }
    public Guid PublisherId { get; set; }
    public Guid AuthorId { get; set; }
    public Guid LibraryBranchId { get; set; }
    public Guid BookStockId { get; set; }

    public string Title { get; set; }
    public string ISBN { get; set; }
    public string Description { get; set; }
    public string CoverImageUrl { get; set; }
    public int PageCount { get; set; }


    public string? AudioFilePath { get; set; }
    public string? FilePath { get; set; }

    public DateTime PublicationDate { get; set; }
    public DateTime OriginalPublicationDate { get; set; }
    public BookStatus BookStatus { get; set; }
    public BookFormat BookFormat { get; set; }
    public BookLanguage BookLanguage { get; set; }
    public bool IsFeatured { get; set; }

    public BookGenre Genre { get; set; }
    public BookPublisher Publisher { get; set; }

    public LibraryBranch LibraryBranch { get; set; }
    public ICollection<BookTag> Tags { get; set; }
    public ICollection<Author> Authors { get; set; }
    public ICollection<BookStockOLD> BookStocks { get; set; }
    public ICollection<BorrowLend> Borrows { get; set; }
    public ICollection<BookInventory> BookInventories { get; set; }
    
}