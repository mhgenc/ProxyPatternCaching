using ProxyPatternCaching.Application.Dtos;
using ProxyPatternCaching.Application.Dtos.Requests;

namespace ProxyPatternCaching.Application.Services.Interfaces;

public interface IBookService
{
    Task<BookDto?> AddBook(CreateBookRequest request);
    Task<BookDto?> GetBook(string id);
}