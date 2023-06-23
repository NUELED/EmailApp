using EmailApp.Model;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;

namespace EmailApp.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        public EmailService(IConfiguration config)
        {

            _config = config;   
        }

        public async Task SendEmail(EmailDto request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("mozelle.kuhlman48@ethereal.email"));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = request.Body};

            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailUserName").Value, _config.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }



        public async Task SendEmail2(EmailDto request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("smartedem91@gmail.com"));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

            //using var smtp = new SmtpClient();
            //smtp.Connect(_config.GetSection("EmailHost2").Value, 587, SecureSocketOptions.StartTls);
            //smtp.Authenticate(_config.GetSection("EmailUserName2").Value, _config.GetSection("EmailPassword2").Value);
            //smtp.Send(email);
            //smtp.Disconnect(true);


            using (var emailClient = new SmtpClient())
            {
                emailClient.Connect("smtp.gmail.com", 465, MailKit.Security.SecureSocketOptions.SslOnConnect);
                emailClient.Authenticate("smartedem91@gmail.com", "bltapnlyvylilhye");
                emailClient.Send(email);
                emailClient.Disconnect(true);
            }
        }

    }
}
