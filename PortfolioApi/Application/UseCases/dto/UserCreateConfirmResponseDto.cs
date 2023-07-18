namespace PortfolioApi.Application.UseCases.dto;

public record UserCreateConfirmResponseDto
{
    public bool Success { get; set; }
    public string Message { get; set; }
}