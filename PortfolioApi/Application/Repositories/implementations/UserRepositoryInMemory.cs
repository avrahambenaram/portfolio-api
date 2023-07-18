using PortfolioApi.Domain.Entities;

namespace PortfolioApi.Application.Repositories.implementations;

public class UserRepositoryInMemory : IUserRepository
{
    private readonly List<User> _users = new();

    public User? FindById(string userId) => _users.FirstOrDefault(u => u.Id == userId);

    public User? FindByEmail(string userEmail) => _users.FirstOrDefault(u => u.Email == userEmail);

    public void Save(User user)
    {
        this._users.Add(user);
    }

    public void Delete(string userId)
    {
        var user = FindById(userId);
        if (user != null)
            _users.Remove(user);
    }
}