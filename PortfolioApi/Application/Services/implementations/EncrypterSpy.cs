namespace PortfolioApi.Application.Services.implementations;

public class EncrypterSpy : IEncrypter
{
    public string Hash(string password)
    {
        return password;
    }

    public bool Compare(string receivedPassword, string hashedPassword)
    {
        return receivedPassword == hashedPassword;
    }
}