using PortfolioApi.Application.Repositories.implementations;
using PortfolioApi.Application.Services.dto;
using PortfolioApi.Application.Services.implementations;
using PortfolioApi.Application.UseCases;
using PortfolioApi.Application.UseCases.dto;
using PortfolioApi.Domain.Entities;

namespace PortfolioApiTests.Application.UseCases;

[TestFixture]
public class UserCreateConfirmTest
{
    private UsersCode _usersCode;
    private EncrypterSpy _encrypter;
    private UserRepositoryInMemory _userRepository;
    private UserCreateConfirm _userCreateConfirm;
    private string _code;

    [SetUp]
    public void SetUp()
    {
        _usersCode = new UsersCode();
        _encrypter = new EncrypterSpy();
        _userRepository = new UserRepositoryInMemory();
        _userCreateConfirm = new UserCreateConfirm(
            _usersCode,
            _encrypter,
            _userRepository
            );
        
        var user = new User(
            "",
            "user_name",
            "user@example.com",
            "User_password123"
        );
        _userRepository.Save(user);

        _code = _usersCode.GenerateCode();
        var userCode = new UserCodeDto(
            _code,
            user,
            "",
            "",
            ""
            );
        _usersCode.Save(userCode);
    }

    [Test]
    public void TestForEmailNotWaiting()
    {
        var props = new UserCreateConfirmDto("test@example.com", "9877654");
        var result = _userCreateConfirm.Execute(props);
        
        Assert.That(result.Success, Is.False);
    }

    [Test]
    public void TestForInvalidCode()
    {
        var props = new UserCreateConfirmDto("user@example.com", "9877654");
        var result = _userCreateConfirm.Execute(props);
        
        Assert.That(result.Success, Is.False);
    }

    [Test]
    public void TestForSuccessfullyCreation()
    {
        var props = new UserCreateConfirmDto("user@example.com", _code);
        var result = _userCreateConfirm.Execute(props);
        
        Assert.That(result.Success, Is.True);
    }
}