using PortfolioApi.Application.Services.dto;
using PortfolioApi.Errors;

namespace PortfolioApi.Application.Services.implementations;

public class UsersCode : IUsersCode
{
    private readonly List<UserCodeDto> _userCodes = new();

    public string GenerateCode()
    {
        var randomizer = new Random();
        var code = randomizer.Next(1, 1000000);
        return this.FormatCode(code);
    }
    string FormatCode(int code)
    {
        var codeString = code.ToString();

        if (codeString.Length < 6)
        {
            return $"0{codeString}";
        }

        if (codeString.Length < 5)
        {
            return $"00{codeString}";
        }

        if (codeString.Length < 4)
        {
            return $"000{codeString}";
        }

        if (codeString.Length < 3)
        {
            return $"0000{codeString}";
        }

        return codeString.Length < 2 ? $"00000{codeString}" : codeString;
    }

    public void Save(UserCodeDto userCode)
    {
        _userCodes.Add(userCode);
    }

    public UserCodeDto? FindByEmail(string email)
    {
        return _userCodes.Find(userCode => userCode.User.Email == email);
    }

    public void Delete(string email)
    {
        var userCode = _userCodes.FirstOrDefault(userCode => userCode.User.Email == email);
        if (userCode != null)
        {
            this._userCodes.Remove(userCode);
        }
    }
}