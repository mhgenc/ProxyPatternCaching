using ProxyPatternCaching.Domain.Base;

namespace ProxyPatternCaching.Domain.Entities;

public class Book : DbEntity
{
    public string Name { get; set; }
    public string Author { get; set; }
    public string Publisher { get; set; }
}