using HotelWebsite.Models;
using System.Net.Mail;

namespace HotelWebsite.Services
{
    public class EmailService : IEmailService
    {
        private readonly Email _email;

        public EmailService(Email email)
        {
            _email = email;
        }

        public void Send(string address)
        {
            MailMessage mailMessage = new(_email.FromAddress, address)
            {
                Body = "BOOKED!",
                Subject = "Hotel"
            };

            _email.SmtpClient.Send(mailMessage);
        }
    }
}
