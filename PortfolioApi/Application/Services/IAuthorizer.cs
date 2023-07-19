using PortfolioApi.Domain.Entities;

namespace PortfolioApi.Application.Services;

public interface IAuthorizer
{
    bool IsAdminUser(User user);
}