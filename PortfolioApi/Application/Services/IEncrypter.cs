namespace PortfolioApi.Application.Services;

public interface IEncrypter
{
    string Hash(string password);
    bool Compare(string receivedPassword, string hashedPassword);
}