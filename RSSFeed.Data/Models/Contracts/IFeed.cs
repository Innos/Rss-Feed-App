namespace RssFeed.Data.Models.Contracts
{
    using RssFeed.Data.Models.Contracts.Common;

    public interface IFeed : IDeletableEntity
    {
        long Id { get; set; }

        string Url { get; set; }

        int ArticlesCount { get; set; }
    }
}
