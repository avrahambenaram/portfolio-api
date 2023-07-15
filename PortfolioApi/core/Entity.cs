using System;

namespace PortfolioApi.core;

public class Entity
{
    public readonly string Id;
    public readonly long CreatedAt;
    public readonly long UpdatedAt;
    
    protected Entity(EntityProps? entityProps)
    {
    {
        var timeOffset = DateTimeOffset.Now;
        var now = timeOffset.ToUnixTimeMilliseconds();

        this.Id = entityProps?.Id ?? Guid.NewGuid().ToString();
        this.CreatedAt = entityProps?.CreatedAt ?? now;
        this.UpdatedAt = entityProps?.UpdatedAt ?? now;
    }}
}