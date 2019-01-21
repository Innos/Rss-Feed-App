using RssFeed.Data.Models;
using RssFeed.Data.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssFeed.Data
{
    using RssFeed.Data.Models;
    using RssFeed.Data.Repositories.Contracts;

    public interface IRssFeedData
    {
       DbContext Context { get; }

       IRepository<ActivityLog> ActivityLogs { get; }

       IDeletableEntityRepository<PersonalCategory> Categories { get; }

       IDeletableEntityRepository<Feed> Feeds { get; }

       IDeletableEntityRepository<PersonalFeed> PersonalFeed { get; }

       IRepository<UnreadArticle> UnreadArticles { get; }

       int SaveChanges();
    }
}
