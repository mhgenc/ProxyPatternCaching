using Microsoft.Extensions.Options;
using ProxyPatternCaching.Domain.Entities;
using ProxyPatternCaching.Infrastructure.Repositories.Base;
using ProxyPatternCaching.Infrastructure.Repositories.Interfaces;
using ProxyPatternCaching.Infrastructure.Settings;

namespace ProxyPatternCaching.Infrastructure.Repositories;

public class BookRepository : GenericRepository<Book>, IBookRepository
{
    public BookRepository(IOptions<MongoDbSettings> options) : base(options)
    {
    }
}