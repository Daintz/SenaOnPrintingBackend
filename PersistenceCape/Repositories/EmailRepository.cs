using PersistenceCape.EmailConfiguration;
using MailKit.Net.Smtp;
using MimeKit;
using PersistenceCape.Interfaces;

namespace PersistenceCape.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        private readonly EmailConfiguration.EmailConfiguration _emailConfiguration;

        public EmailRepository(EmailConfiguration.EmailConfiguration emailConfiguration) => _emailConfiguration = emailConfiguration;

        void IEmailRepository.SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);
            Send(emailMessage);
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("SENAonPrinting", _emailConfiguration.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = message.Body };

            return emailMessage;
        }
        private void Send(MimeMessage mailMessage)
        {
            using var serverClient = new SmtpClient();
            try
            {
                serverClient.Connect(_emailConfiguration.Server, _emailConfiguration.Port, true);                 
                serverClient.AuthenticationMechanisms.Remove("XOAUTH2");
                serverClient.Authenticate(_emailConfiguration.EmailAddress, _emailConfiguration.EmailPassword);

                serverClient.Send(mailMessage);
            } catch (Exception ex)
            {
                throw;
            }
            finally {
                serverClient.Disconnect(true);
                serverClient.Dispose(); 
            }
        }
    }
}
