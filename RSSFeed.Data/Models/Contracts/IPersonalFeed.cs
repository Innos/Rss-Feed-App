namespace RSSFeed.Data.Models.Contracts
{
    using System.Collections.Generic;

    using RSSFeed.Data.Models.Contracts.Common;

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
