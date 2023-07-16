namespace PortfolioApi.Application.UseCases.dto;

public record UserCreateDto(string Name, string Email, string Password, string Redirect, string FailureRedirect, string Address);