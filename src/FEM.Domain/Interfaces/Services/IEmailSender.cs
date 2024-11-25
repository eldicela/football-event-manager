
namespace FEM.Domain.Interfaces.Services;


public interface IEmailSender
{
    Task<bool> SendMailAsync(Common.MailData mail);
}
