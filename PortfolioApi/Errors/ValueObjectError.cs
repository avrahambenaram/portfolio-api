namespace PortfolioApi.Errors;

public class ValueObjectError : ErrorException
{
    public ValueObjectError(string message) : base(message, 403)
    {}
}