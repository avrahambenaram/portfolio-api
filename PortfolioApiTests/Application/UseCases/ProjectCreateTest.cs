using PortfolioApi.Application.Repositories.implementations;
using PortfolioApi.Application.UseCases;
using PortfolioApi.Application.UseCases.dto;
using PortfolioApi.Domain.Entities;
using PortfolioApi.Errors;
using PortfolioApiTests.Utils;

namespace PortfolioApiTests.Application.UseCases;

public class ProjectCreateTest
{
    private InvalidFlowError _invalidFlow;
    private ProjectRepositoryInMemory _projectRepository;
    private AuthorizerStub _authorizer;
    private ProjectCreate _projectCreate;
    private User _user;
    private User _adminUser;

    [SetUp]
    public void SetUp()
    {
        _invalidFlow = new InvalidFlowError();
        _projectRepository = new ProjectRepositoryInMemory();
        _authorizer = new AuthorizerStub();
        _projectCreate = new ProjectCreate(
            _projectRepository,
            _authorizer
            );
        
        _user = new User(
            "",
            "user_name",
            "user@example.com",
            "User_password123"
        );
        _adminUser = new User(
            "",
            "user_name",
            "admin@example.com",
            "User_password123"
        );
        _authorizer.SetAuthorizedEmail(_adminUser.Email);
    }

    [Test]
    public void TestForUnauthorizedUser()
    {
        try
        {
            var props = new ProjectCreateDto(
                _user,
                "name",
                "previewDescription",
                "description",
                "external",
                "github",
                new List<string>()
            );
            _projectCreate.Execute(props);
            _invalidFlow.Generate();
        }
        catch (Exception err)
        {
            Assert.IsInstanceOf<UseCaseError>(err);
        }
    }

    [Test]
    public void TestForProjectCreationSuccess()
    {
        var props = new ProjectCreateDto(
            _adminUser,
            "name",
            "previewDescription",
            "description",
            "external",
            "github",
            new List<string>()
        );
        _projectCreate.Execute(props);

        var project = _projectRepository.FindLast();
        
        Assert.That(project, Is.Not.Null);
        Assert.That(project.Name, Is.EqualTo("name"));
    }
}