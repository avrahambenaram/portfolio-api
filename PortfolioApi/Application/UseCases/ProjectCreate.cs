using PortfolioApi.Application.Repositories;
using PortfolioApi.Application.Services;
using PortfolioApi.Application.UseCases.dto;
using PortfolioApi.Domain.Entities;
using PortfolioApi.Errors;

namespace PortfolioApi.Application.UseCases;

public class ProjectCreate
{
    private readonly IProjectRepository _projectRepository;
    private readonly IAuthorizer _authorizer;

    public ProjectCreate(IProjectRepository projectRepository, IAuthorizer authorizer)
    {
        _projectRepository = projectRepository;
        _authorizer = authorizer;
    }

    public void Execute(ProjectCreateDto props)
    {
        if (!_authorizer.IsAdminUser(props.User))
            throw new UseCaseError("Usuário não autorizado", 401);

        var project = new Project(
            props.Name,
            props.PreviewDescription,
            props.Description,
            props.External,
            props.Github,
            props.Images
        );
        _projectRepository.Save(project);
    }
}