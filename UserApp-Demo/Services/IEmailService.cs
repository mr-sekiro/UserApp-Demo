namespace UserApp_Demo.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string Subject, string Body);
    }
}
