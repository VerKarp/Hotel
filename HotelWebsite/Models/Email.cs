using System.Net.Mail;

namespace HotelWebsite.Models
{
    public class Email
    {
        private readonly IConfiguration _configuration;

        public SmtpClient SmtpClient { get; private set; }
        public string FromAddress { get; private set; }

        public Email(IConfiguration configuration)
        {
            _configuration = configuration;

            ConfigureSmtpClient();
        }

        private void ConfigureSmtpClient()
        {
            SmtpClient = new SmtpClient("smtp.office365.com", 587);

            FromAddress = _configuration["Emails:BaseEmail"]!;
            var password = _configuration["Emails:BasePassword"];

            System.Net.NetworkCredential basicCredential = new(FromAddress, password);

            SmtpClient.UseDefaultCredentials = false;
            SmtpClient.EnableSsl = true;
            SmtpClient.Credentials = basicCredential;
        }
    }
}
