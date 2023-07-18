namespace PortfolioApiTests.Utils;

public class InvalidFlowError
{
    public void Generate()
    {
        throw new Exception("Invalid flow");
    }
}