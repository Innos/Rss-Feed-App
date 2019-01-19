namespace RSSFeed.Data.Models.Contracts
{
    using RSSFeed.Data.Models.Contracts.Common;

    public interface IFeed : IDeletableEntity
    {
        long Id { get; set; }

        string Url { get; set; }

        int ArticlesCount { get; set; }
    }
}
