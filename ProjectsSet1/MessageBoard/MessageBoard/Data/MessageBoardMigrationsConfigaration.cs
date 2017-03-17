using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace MessageBoard.Data
{
    public class MessageBoardMigrationsConfigaration 
        :DbMigrationsConfiguration<MessageBoardContext>
    {
        public MessageBoardMigrationsConfigaration()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MessageBoardContext context)
        {
            base.Seed(context);
#if DEBUG
            if (context.Topics.Count() == 0)
            {
                var topic = new Topic()
                {
                    Title = "I Love MVC",
                    Body = "I love asp.net MVC and I want everyone to know it",
                    Created = DateTime.UtcNow,
                    Replies = new List<Reply>(){
                        new Reply()
                        {
                            Body = "I love it too",
                            Created = DateTime.UtcNow
                        },
                        new Reply()
                        {
                            Body ="Thank you for the feedback",
                            Created = DateTime.UtcNow
                        },
                        new Reply()
                        {
                            Body = "Interesting",
                            Created = DateTime.UtcNow
                        },
                    }
                    
                };
                context.Topics.Add(topic);

                var anotherTopic = new Topic()
                {
                    Title = "The Ruby",
                    Body = "Ruby on Rails is popular",
                    Created = DateTime.UtcNow

                };
                context.Topics.Add(anotherTopic);
                try
                {
                    context.SaveChanges();
                }
                catch(Exception ex)
                {
                    var msg = ex.Message;
                }
            }
#endif
        }
    }
}