using PortfolioApi.Domain.Entities;

namespace PortfolioApi.Application.Repositories.implementations;

public class ProjectRepositoryInMemory : IProjectRepository
{
    private List<Project> _projects = new();

    public Project? FindLast()
    {
        return _projects.Last();
    }
    
    public void Save(Project project)
    {
        _projects.Add(project);
    }
}