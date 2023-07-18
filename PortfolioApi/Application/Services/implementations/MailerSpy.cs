using PortfolioApi.Application.Services.dto;

namespace PortfolioApi.Application.Services.implementations;

public class MailerSpy : IMailer
{
    public List<MailerDto> ConfirmationEmails = new();
    public List<MailerDto> RecoverEmails = new();

    public void SendConfirmationEmail(MailerDto props)
    {
        ConfirmationEmails.Add(props);
    }

    public void SendRecoverEmail(MailerDto props)
    {
        RecoverEmails.Add(props);
    }
}