using System;
using System.Linq;

namespace MessageBoard.Data
{
    public class MessageBoardRepository : IMessageBoardRepository
    {
        MessageBoardContext _context;
        public MessageBoardRepository(MessageBoardContext ctx)
        {
            _context = ctx;
        }
        
        public IQueryable<Topic> GetTopics()
        {
            return _context.Topics.Include("Replies");
        }
        public IQueryable<Reply> GetRepliesByTopic(int topicId)
        {
            return _context.Replies.Where(t => t.TopicId == topicId);
        }

        public IQueryable<Topic> GetTopics(int id)
        {
            return _context.Topics
                .Include("Replies")
                .Where(t => t.Id == id);
                            
        }

        public bool Save()
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                //TODO log this error
                return false;
            }
        }

        public bool AddTopic(Topic newTopic)
        {
            _context.Topics.Add(newTopic);
            return true;
        }

        public bool AddReply(Reply newReply)
        {
            _context.Replies.Add(newReply);
            return true;
        }
    }
}