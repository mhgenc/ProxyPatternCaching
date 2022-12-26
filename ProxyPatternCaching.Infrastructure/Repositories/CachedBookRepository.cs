using Microsoft.Extensions.Caching.Memory;
using ProxyPatternCaching.Domain.Entities;
using ProxyPatternCaching.Infrastructure.Constants;
using ProxyPatternCaching.Infrastructure.Repositories.Interfaces;

namespace ProxyPatternCaching.Infrastructure.Repositories;

public class CachedBookRepository : IBookRepository
{
    private readonly BookRepository _bookRepository;
    private readonly IMemoryCache _memoryCache;

    public CachedBookRepository(BookRepository bookRepository, IMemoryCache memoryCache)
    {
        _bookRepository = bookRepository;
        _memoryCache = memoryCache;
    }

    public async Task<Book?> GetByIdAsync(string id)
    {
        var book = await _memoryCache.GetOrCreateAsync(CachePrefixes.Book + id, entry => _bookRepository.GetByIdAsync(id));
        return book;
    }

    public async Task<Book> AddAsync(Book entity)
    {
        var book = await _bookRepository.AddAsync(entity);
        _memoryCache.Set(CachePrefixes.Book + book.Id, book);
        return book;
    }
}