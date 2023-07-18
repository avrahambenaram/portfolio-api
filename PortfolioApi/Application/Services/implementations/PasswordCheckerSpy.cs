namespace PortfolioApi.Application.Services.implementations;

public class PasswordCheckerSpy : IPasswordChecker
{
    private bool _isWeak = false;

    public bool IsPasswordWeak(string password)
    {
        return _isWeak;
    }

    public void SetIsWeak(bool isWeak)
    {
        _isWeak = isWeak;
    }
}