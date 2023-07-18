using PortfolioApi.Application.Repositories.implementations;
using PortfolioApi.Application.Services.implementations;
using PortfolioApi.Application.UseCases;
using PortfolioApi.Application.UseCases.dto;
using PortfolioApi.Domain.Entities;
using PortfolioApi.Errors;
using PortfolioApiTests.Utils;

namespace PortfolioApiTests.Application.UseCases;

public class UserCreateTest
{
    private InvalidFlowError _invalidFlow;
    private UsersCode _usersCode;
    private UserRepositoryInMemory _userRepository;
    private MailerSpy _mailer;
    private PasswordCheckerSpy _passwordChecker;
    private UserCreate _userCreate;

    [SetUp]
    public void SetUp()
    {
        _invalidFlow = new InvalidFlowError();
        _usersCode = new UsersCode();
        _userRepository = new UserRepositoryInMemory();
        _mailer = new MailerSpy();
        _passwordChecker = new PasswordCheckerSpy();
        _userCreate = new UserCreate(
            _userRepository,
            _usersCode,
            _mailer,
            _passwordChecker
            );

        var user = new User(
            "",
            "user_name",
            "user@example.com",
            "User_password123"
        );
        _userRepository.Save(user);
    }

    [Test]
    public void TestForInvalidEmail()
    {
        try
        {
            var props = new UserCreateDto(
                "Any_user_name",
                "jy456nu465",
                "User_password123",
                "",
                "",
                "any_address"
            );
            _userCreate.Execute(props);
            _invalidFlow.Generate();
        }
        catch (Exception err)
        {
            Assert.IsInstanceOf<ValueObjectError>(err);
        }
    }

    [Test]
    public void TestForNameTooLong()
    {
        try
        {
            var props = new UserCreateDto(
                "A too long name for throwing an expected error",
                "email@example.com",
                "User_password123",
                "",
                "",
                "any_address"
            );
            _userCreate.Execute(props);
            _invalidFlow.Generate();
        }
        catch (Exception err)
        {
            Assert.IsInstanceOf<ValueObjectError>(err);
        }
    }

    [Test]
    public void TestForUserAlreadyExists()
    {
        try
        {
            var props = new UserCreateDto(
                "Avraham",
                "user@example.com",
                "User_password123",
                "",
                "",
                "any_address"
            );
            _userCreate.Execute(props);
            _invalidFlow.Generate();
        }
        catch (Exception err)
        {
            Assert.IsInstanceOf<UseCaseError>(err);
        }
    }
    
    [Test]
    public void TestCreatingUserSuccessfully()
    {
        var props = new UserCreateDto(
            "Avraham",
            "avraham@example.com",
            "User_password123",
            "",
            "",
            "any_address"
        );
        _userCreate.Execute(props);

        var code = this._usersCode.FindByEmail("user@example.com");
        
        Assert.That(code.User.Email, Is.EqualTo("user@example.com"));
    }
}