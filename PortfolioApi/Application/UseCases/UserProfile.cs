using PortfolioApi.Application.Repositories;
using PortfolioApi.Domain.Entities;
using PortfolioApi.Errors;

namespace PortfolioApi.Application.UseCases;

public class UserProfile
{
    private IUserRepository _userRepository;

    public UserProfile(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public User Execute(string userId)
    {
        var user = _userRepository.FindById(userId);
        if (user == null)
            throw new UseCaseError("Usuário não encontrado", 404);

        return user;
    }
}