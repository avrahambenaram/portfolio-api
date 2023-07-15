using PortfolioApi.core;
using PortfolioApi.Domain.ValueObjects;

namespace PortfolioApi.Domain.Entities;

public class User : Entity
{
    public readonly string Avatar;
    public readonly string Name;
    public readonly string Email;
    public readonly string Password;
    
    public User(string avatar, string name, string email, string password, EntityProps? entityProps) : base(entityProps)
    {
        this.Avatar = avatar;
        this.Name = new Name(name).Value;
        this.Email = new Email(email).Value;
        this.Password = new Password(password).Value;
    }
}