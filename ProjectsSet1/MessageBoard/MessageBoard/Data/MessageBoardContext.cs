﻿using System.Data.Entity;


namespace MessageBoard.Data
{
    public class MessageBoardContext:DbContext
    {
        public MessageBoardContext()
            : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<MessageBoardContext,MessageBoardMigrationsConfigaration>()
                );
        }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Reply> Replies { get; set; }
    }
}