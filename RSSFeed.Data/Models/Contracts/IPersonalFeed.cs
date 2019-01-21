namespace RssFeed.Data.Models.Contracts
{
    using System.Collections.Generic;

    using RssFeed.Data.Models.Contracts.Common;

    public interface IPersonalFeed : IDeletableEntity
    {
        long Id { get; set; }

        long CategoryId { get; set; }

        PersonalCategory Category { get; set; }

        long FeedId { get; set; }

        Feed Feed { get; set; }

        int LastKnownArticleId { get; set; }

        ICollection<UnreadArticle> UnreadArticles { get; set; }
    }
}
