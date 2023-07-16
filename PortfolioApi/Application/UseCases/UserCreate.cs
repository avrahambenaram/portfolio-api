using PortfolioApi.Application.Repositories;
using PortfolioApi.Application.Services;
using PortfolioApi.Application.Services.dto;
using PortfolioApi.Application.UseCases.dto;
using PortfolioApi.Domain.Entities;
using PortfolioApi.Errors;

namespace PortfolioApi.Application.UseCases;

public class UserCreate
{
    private readonly IUserRepository _userRepository;
    private readonly IUsersCode _usersCode;
    private readonly IMailer _mailer;
    private readonly IPasswordChecker _passwordChecker;

    public UserCreate(
        IUserRepository userRepository,
        IUsersCode usersCode,
        IMailer mailer,
        IPasswordChecker passwordChecker
        )
    {
        this._userRepository = userRepository;
        this._usersCode = usersCode;
        this._mailer = mailer;
        this._passwordChecker = passwordChecker;
    }

    public void Execute(UserCreateDto props)
    {
        this.VerifyUserExistence(props.Email);
        if (this._passwordChecker.IsPasswordWeak(props.Password))
            throw new UseCaseError("Password too weak", 403);
        var user = new User(
            "",
            props.Name,
            props.Email,
            props.Password
        );
        this.GeenerateUserCode(user, props);
        this.DeleteUserCodeAfter10Minutes(user.Email);
    }

    private void VerifyUserExistence(string userEmail)
    {
        var userFound = this._userRepository.FindById(userEmail);
        if (userFound != null)
            throw new UseCaseError("User already exists", 403);
    }

    private void GeenerateUserCode(User user, UserCreateDto props)
    {
        var code = this._usersCode.GenerateCode();
        var mailProps = new MailerDto(user.Name, user.Email, code);
        this._mailer.SendConfirmationEmail(mailProps);

        UserCodeDto userCodeProps = new UserCodeDto(
            code,
            user, 
            props.Address,
            props.Redirect,
            props.FailureRedirect
        );
        this._usersCode.Save(userCodeProps);
    }

    private void DeleteUserCodeAfter10Minutes(string userEmail)
    {
        var usersCode = this._usersCode;
        long minutes10 = 1000 * 60 * 10;
        var timer = new System.Timers.Timer();

        timer.Elapsed += (sender, e) =>
        {
            usersCode.Delete(userEmail);
            timer.Stop();
            timer.Dispose();
        };

        timer.Interval = minutes10;
        timer.AutoReset = false;
        timer.Start();
    }
}