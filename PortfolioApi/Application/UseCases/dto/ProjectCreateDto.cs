using PortfolioApi.Domain.Entities;

namespace PortfolioApi.Application.UseCases.dto;

public record ProjectCreateDto(User User, string Name, string PreviewDescription, string Description, string External, string Github, List<string> Images);