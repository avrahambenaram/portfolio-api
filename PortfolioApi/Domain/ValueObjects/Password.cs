using PortfolioApi.Config;
using PortfolioApi.Errors;

namespace PortfolioApi.Domain.ValueObjects;

public class Password
{
    public string Value;

    public Password(string password)
    {
        bool isPasswordTooShort = password.Length < ValueObjectsConfig.Password.MinLength;
        bool isPasswordTooLong = password.Length > ValueObjectsConfig.Password.MaxLength;

        if (isPasswordTooShort)
            throw new ValueObjectError("Password too short");
        if (isPasswordTooLong)
            throw new ValueObjectError("Password too long");
            
        this.Value = password;
    }
}