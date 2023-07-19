using PortfolioApi.Application.Repositories.implementations;
using PortfolioApi.Application.UseCases;
using PortfolioApi.Domain.Entities;
using PortfolioApiTests.Utils;

namespace PortfolioApiTests.Application.UseCases;

public class UserDeleteUseCase
{
    private InvalidFlowError _invalidFlow;
    private UserRepositoryInMemory _userRepository;
    private UserDelete _userDelete;
    private User _user;

    [SetUp]
    public void SetUp()
    {
        _invalidFlow = new InvalidFlowError();
        _userRepository = new UserRepositoryInMemory();
        _userDelete = new UserDelete(_userRepository);
        _user = new User(
            "",
            "user_name",
            "user@example.com",
            "User_password123"
        );
        _userRepository.Save(_user);
    }

    [Test]
    public void TestForSuccessDelete()
    {
        _userDelete.Execute(_user.Id);

        var user = _userRepository.FindById(_user.Id);
        Assert.That(user, Is.Null);
    }
}