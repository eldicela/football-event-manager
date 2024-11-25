

using FEM.Domain.Interfaces.Services;
using FEM.Domain.Common;
using MailKit;
using MimeKit;
using Microsoft.Extensions.Configuration;
using MailKit.Net.Smtp;

namespace FEM.Infrastructure.EmailSender;

internal class Sender
{
    public string Host { get; set; }
    public int Port { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}

internal class EmailSender : IEmailSender
{

    private readonly Sender _sender;

    public EmailSender(IServiceProvider serviceProvider, IConfiguration configuration)
    {
        _sender = new Sender
        {
            Host = configuration["EmailSender:Host"],
            Port = int.Parse(configuration["EmailSender:Port"]),
            Email = configuration["EmailSender:Email"],
            Name = configuration["EmailSender:Name"],
            Username = configuration["EmailSender:Username"],
            Password = configuration["EmailSender:Password"]
        };
    }


    public async Task<bool> SendMailAsync(MailData mail)
    {
        try
        {
            using (MimeMessage msg = new MimeMessage())
            {
                msg.From.Add(new MailboxAddress(_sender.Name, _sender.Email));
                msg.To.Add(new MailboxAddress(mail.To, mail.To));

                msg.Subject = mail.Subject;


                BodyBuilder builder = new BodyBuilder();
                builder.HtmlBody = mail.Body;
                msg.Body = builder.ToMessageBody();


                //using (SmtpClient smtp = new SmtpClient())
                using (SmtpClient smtp = new SmtpClient()) 
                {
                 
                    await smtp.ConnectAsync(_sender.Host, _sender.Port, false);
                    await smtp.AuthenticateAsync(_sender.Username, _sender.Password);
                    await smtp.SendAsync(msg);
                    await smtp.DisconnectAsync(true);

                }
                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return false;
        }
    }
}
