using System.Linq.Expressions;
using FleetManagement.Application.Repositories;
using FleetManagement.Domain.Base;
using FleetManagement.Infrastructure.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FleetManagement.Infrastructure.Repositories;

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

    public virtual async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
    {
        return await _collection.Find(predicate).FirstOrDefaultAsync();
    }

    public virtual async Task<bool> Exist(Expression<Func<T, bool>> predicate)
    {
        var data = await _collection.Find(predicate).FirstOrDefaultAsync();
        return data != null;
    }

    public virtual async Task<IEnumerable<T>> GetList(Expression<Func<T, bool>> predicate)
    {
        var cursor = await _collection.FindAsync(predicate);
        return await cursor.ToListAsync();
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

    public virtual async Task AddRangeAsync(IEnumerable<T> entities)
    {
        var options = new InsertManyOptions { IsOrdered = false, BypassDocumentValidation = false };
        await _collection.InsertManyAsync(entities, options);
    }

    public virtual async Task<T> UpdateAsync(string id, T entity)
    {
        var options = new FindOneAndReplaceOptions<T>
        {
            ReturnDocument = ReturnDocument.After
        };

        return await _collection.FindOneAndReplaceAsync<T>(x => x.Id == id, entity, options);
    }

    public virtual async Task<bool> UpdateRangeAsync(IEnumerable<T> entities)
    {
        var updates = new List<WriteModel<T>>();
        var filterBuilder = Builders<T>.Filter;

        foreach (var doc in entities)
        {
            var filter = filterBuilder.Where(x => x.Id == doc.Id);
            updates.Add(new ReplaceOneModel<T>(filter, doc));
        }

        var options = new BulkWriteOptions { IsOrdered = false, BypassDocumentValidation = false };

        return (await _collection.BulkWriteAsync(updates, options)).IsAcknowledged;
    }
}