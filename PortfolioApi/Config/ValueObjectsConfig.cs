namespace PortfolioApi.Config;

public static class ValueObjectsConfig
{
    public static Lengther Name = new Lengther(2, 30);
    public static Lengther Email = new Lengther(2, 60);
    public static Lengther Password = new Lengther(5, Int32.MaxValue);
}