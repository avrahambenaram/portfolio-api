namespace PortfolioApi.Errors;

public class ErrorException : Exception
{
    public int StatusCodee;

    public ErrorException(string message, int statusCode) : base(message)
    {
        this.StatusCodee = statusCode;
    }
}