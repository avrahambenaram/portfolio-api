using PortfolioApi.Application.Repositories.implementations;
using PortfolioApi.Application.UseCases;
using PortfolioApi.Domain.Entities;
using PortfolioApi.Errors;
using PortfolioApiTests.Utils;

namespace PortfolioApiTests.Application.UseCases;

[TestFixture]
public class UserProfileTest
{
    private InvalidFlowError _invalidFlow;
    private UserRepositoryInMemory _userRepository;
    private UserProfile _userProfile;
    private User _user;

    [SetUp]
    public void SetUp()
    {
        _invalidFlow = new InvalidFlowError();
        _userRepository = new UserRepositoryInMemory();
        _userProfile = new UserProfile(_userRepository);
        
        _user = new User(
            "",
            "user_name",
            "user@example.com",
            "User_password123"
        );
        _userRepository.Save(_user);
    }

    [Test]
    public void TestForUserNotFound()
    {
        try
        {
            _userProfile.Execute("any_user_id");
            _invalidFlow.Generate();
        }
        catch (Exception err)
        {
            Assert.IsInstanceOf<UseCaseError>(err);
        }
    }

    [Test]
    public void TestForUserProfileSuccess()
    {
        var user = _userProfile.Execute(_user.Id);
        
        Assert.That(user, Is.EqualTo(_user));
    }
}