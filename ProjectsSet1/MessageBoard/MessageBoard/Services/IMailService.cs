namespace MessageBoard.Services
{
    public interface IMailService
    {
        bool SentMail(string from, string to, string subject, string body);
    }
}