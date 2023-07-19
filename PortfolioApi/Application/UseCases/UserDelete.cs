using PortfolioApi.Application.Repositories;

namespace PortfolioApi.Application.UseCases;

public class UserDelete
{
    private IUserRepository _userRepository;
    
    public UserDelete(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void Execute(string userId)
    {
        _userRepository.Delete(userId);
    }
}