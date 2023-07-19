using PortfolioApi.core;

namespace PortfolioApi.Domain.Entities;

public class Project : Entity
{
    public readonly string Name;
    public readonly string PreviewDescription;
    public readonly string Description;
    public readonly string External;
    public readonly string Github;
    public readonly List<string> Images;
    
    public Project(string name, string previewDescription, string description, string external, string github, List<string>? images = null, EntityProps? entityProps = null) : base(entityProps)
    {
        this.Name = name;
        this.PreviewDescription = previewDescription;
        this.Description = description;
        this.External = external;
        this.Github = github;
        this.Images = images ?? new List<string>();
    }
}