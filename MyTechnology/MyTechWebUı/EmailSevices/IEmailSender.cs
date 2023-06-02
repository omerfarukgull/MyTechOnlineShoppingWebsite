namespace MyTechWebUı.EmailSevices
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage);

    }
}
