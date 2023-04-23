using EmailApp.Model;

namespace EmailApp.Services.EmailService
{
    public interface IEmailService
    {
        Task  SendEmail(EmailDto request);
    }
}
