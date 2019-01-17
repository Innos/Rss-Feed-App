using RSSFeed.Data.Models;
using RSSFeed.Data.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSFeed.Data
{
    public interface IRssFeedData
    {
       DbContext Context { get; }

       IRepository<ActivityLog> ActivityLogs { get; }

       IDeletableEntityRepository<Category> Categories { get; }

       IDeletableEntityRepository<Feed> Feeds { get; }

       IDeletableEntityRepository<PersonalFeed> PersonalFeed { get; }

       IRepository<UnreadArticle> UnreadArticles { get; }

       int SaveChanges();
    }
}
