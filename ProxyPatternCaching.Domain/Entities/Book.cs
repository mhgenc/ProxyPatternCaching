using ProxyPatternCaching.Domain.Base;

namespace ProxyPatternCaching.Domain;

public class Book : DbEntity
{
    public string Name { get; set; }
}