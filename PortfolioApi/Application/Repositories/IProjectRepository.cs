using PortfolioApi.Domain.Entities;

namespace PortfolioApi.Application.Repositories;

public interface IProjectRepository
{
    Project? FindLast();
    void Save(Project project);
}