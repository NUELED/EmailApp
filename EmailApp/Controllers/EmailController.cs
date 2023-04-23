using EmailApp.Model;
using EmailApp.Services.EmailService;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace EmailApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;    
        public EmailController( IEmailService emailService)
        {
            _emailService = emailService;   
        }


        [HttpPost]
        public async Task<IActionResult> SendEmail(EmailDto  request)
        {
            //var email = new MimeMessage();
            //email.From.Add(MailboxAddress.Parse("mozelle.kuhlman48@ethereal.email"));
            //email.To.Add(MailboxAddress.Parse("mozelle.kuhlman48@ethereal.email"));
            //email.Subject = "Test Email Subject";
            //email.Body = new TextPart(TextFormat.Html) { Text = body };

            //using var smtp = new SmtpClient();  
            //smtp.Connect("smtp.ethereal.email",587,SecureSocketOptions.StartTls);
            //smtp.Authenticate("mozelle.kuhlman48@ethereal.email", "vUWJ5Z4C1SS1U3Qm2Q");
            //smtp.Send(email);
            //smtp.Disconnect(true);
            _emailService.SendEmail(request);

            return Ok();
        }
    }
}
