namespace PortfolioApi.Errors;

public class UseCaseError : ErrorException
{
    public UseCaseError(string message, int statusCode): base(message, statusCode)
    {}
}