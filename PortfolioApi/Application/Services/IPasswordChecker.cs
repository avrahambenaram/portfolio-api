namespace PortfolioApi.Application.Services;

public interface IPasswordChecker
{
    bool IsPasswordWeak(string password);
}