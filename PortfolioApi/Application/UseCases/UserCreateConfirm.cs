using PortfolioApi.Application.Repositories;
using PortfolioApi.Application.Services;
using PortfolioApi.Application.Services.dto;
using PortfolioApi.Application.UseCases.dto;
using PortfolioApi.Domain.Entities;

namespace PortfolioApi.Application.UseCases;

public class UserCreateConfirm
{
    private readonly UserCreateConfirmResponseDto _result = new UserCreateConfirmResponseDto
    {
        Success = false,
        Message = ""
    };
    private readonly IUsersCode _usersCode;
    private readonly IEncrypter _encrypter;
    private readonly IUserRepository _userRepository;

    public UserCreateConfirm(IUsersCode usersCode, IEncrypter encrypter, IUserRepository userRepository)
    {
        _usersCode = usersCode;
        _encrypter = encrypter;
        _userRepository = userRepository;
    }

    public UserCreateConfirmResponseDto Execute(UserCreateConfirmDto props)
    {
        var userCode = _usersCode.FindByEmail(props.Email);
        if (userCode == null)
        {
            _result.Message = "Não há um código em espera";
            return _result;
        }
        if (userCode.Code == props.Code)
        {
           this.CreateUser(userCode);
        }
        else
        {
            _result.Message = "Código inválido";
        }
        
        return _result;
    }

    private void CreateUser(UserCodeDto userCode)
    {
        var user = new User(
            "",
            userCode.User.Name,
            userCode.User.Email,
            _encrypter.Hash(userCode.User.Password)
            );
        _userRepository.Save(user);
        _result.Success = true;
    }
}