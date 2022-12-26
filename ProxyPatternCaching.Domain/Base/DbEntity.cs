using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProxyPatternCaching.Domain.Base;

public class DbEntity : IEntity
{
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonId]
    [BsonElement(Order = 0)]
    public string Id { get; set; }

    [BsonRepresentation(BsonType.DateTime)]
    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    [BsonElement(Order = 101)]
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
}