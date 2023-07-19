using PortfolioApi.Application.Services.dto;

namespace PortfolioApi.Application.Services;

public interface IUsersCode
{
    string GenerateCode();
    void Save(UserCodeDto userCode);
    UserCodeDto? FindByEmail(string email);
    void Delete(string email);
}