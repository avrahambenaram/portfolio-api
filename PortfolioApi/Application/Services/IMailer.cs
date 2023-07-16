using PortfolioApi.Application.Services.dto;

namespace PortfolioApi.Application.Services;

public interface IMailer
{
    public void SendConfirmationEmail(MailerDto props);
    public void SendRecoverEmail(MailerDto props);
}