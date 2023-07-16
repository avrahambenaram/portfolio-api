using PortfolioApi.Domain.Entities;

namespace PortfolioApi.Application.Services.dto;

public record UserCodeDto(string Code, User User, string Redirect, string FailureRedirect, string Address);