using PortfolioApi.Config;
using PortfolioApi.Errors;

namespace PortfolioApi.Domain.ValueObjects;

public class Name
{
    public string Value;

    public Name(string name)
    {
        bool isNameTooShort = name.Length < ValueObjectsConfig.Name.MinLength;
        bool isNameTooLong = name.Length > ValueObjectsConfig.Name.MaxLength;

        if (isNameTooShort)
            throw new ValueObjectError("Name too short");
        if (isNameTooLong)
            throw new ValueObjectError("Name too long");

        this.Value = name;
    }
}