using System.Text.RegularExpressions;
using PortfolioApi.Config;
using PortfolioApi.Errors;

namespace PortfolioApi.Domain.ValueObjects;

public class Email
{
    public string Value;
    private readonly string _emailPattern = @"^[\w\.-]+@[\w\.-]+\.\w+$";

    public Email(string email)
    {
        bool isValidEmail = Regex.IsMatch(email, this._emailPattern);
        bool isEmailTooShort = email.Length < ValueObjectsConfig.Email.MinLength;
        bool isEmailTooLong = email.Length > ValueObjectsConfig.Email.MaxLength;

        if (!isValidEmail)
            throw new ValueObjectError("Invalid email");
        if (isEmailTooShort)
            throw new ValueObjectError("Email too short");
        if (isEmailTooLong)
            throw new ValueObjectError("Email too long");
        
        this.Value = email;
    }
}