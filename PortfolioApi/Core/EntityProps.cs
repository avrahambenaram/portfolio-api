namespace PortfolioApi.core;

public record EntityProps
{
    public string? Id { get; set; }
    public long? CreatedAt { get; set; }
    public long? UpdatedAt { get; set; }
}