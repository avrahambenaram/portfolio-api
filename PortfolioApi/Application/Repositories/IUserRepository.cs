using PortfolioApi.Domain.Entities;

namespace PortfolioApi.Application.Repositories;

public interface IUserRepository
{
    User? FindById(string userId);
    User? FindByEmail(string userEmail);
    void Save(User user);
    void Delete(string userId);
}