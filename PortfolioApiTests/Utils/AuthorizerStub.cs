using PortfolioApi.Application.Services;
using PortfolioApi.Domain.Entities;

namespace PortfolioApiTests.Utils;

public class AuthorizerStub : IAuthorizer
{
    private string _authorizedEmail;
    
    public bool IsAdminUser(User user)
    {
        return user.Email == _authorizedEmail;
    }

    public void SetAuthorizedEmail(string email)
    {
        _authorizedEmail = email;
    }
}