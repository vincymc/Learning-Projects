using System.Diagnostics;

namespace MessageBoard.Services
{
    public class MockMailService : IMailService
    {
        public bool SentMail(string from, string to, string subject, string body)
        {
            Debug.WriteLine("SendMail: "+ subject);
            return true;
        }
    }
}