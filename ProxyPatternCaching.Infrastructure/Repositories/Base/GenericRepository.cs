using System.Linq.Expressions;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProxyPatternCaching.Domain.Base;
using ProxyPatternCaching.Infrastructure.Settings;

namespace ProxyPatternCaching.Infrastructure.Repositories.Base;

public class GenericRepository<T> : IGenericRepository<T> where T : DbEntity, new()
{
    private readonly IMongoCollection<T> _collection;

    public GenericRepository(IOptions<MongoDbSettings> options)
    {
        var settings = options.Value;
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);
        _collection = database.GetCollection<T>(typeof(T).Name.ToLowerInvariant());
    }

    public virtual async Task<T?> GetByIdAsync(string id)
    {
        return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public virtual async Task<T> AddAsync(T entity)
    {
        var options = new InsertOneOptions { BypassDocumentValidation = false };
        await _collection.InsertOneAsync(entity, options);
        return entity;
    }
}