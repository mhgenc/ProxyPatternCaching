namespace ProxyPatternCaching.Application.Dtos.Requests;

public class CreateBookRequest
{
    public string Name { get; set; }
    public string Author { get; set; }
    public string Publisher { get; set; }
}