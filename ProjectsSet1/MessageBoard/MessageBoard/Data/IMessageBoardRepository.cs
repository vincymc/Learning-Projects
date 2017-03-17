using System.Linq;

namespace MessageBoard.Data
{
    public interface IMessageBoardRepository
    {
        IQueryable<Topic> GetTopics();
        IQueryable<Topic> GetTopics(int id);
        IQueryable<Reply> GetRepliesByTopic(int topicId);

        bool Save();

        bool AddTopic(Topic newTopic);
        bool AddReply(Reply newReply);
    }
}
