namespace RssFeed.Services.PersonalFeedsService
{
    using System.Linq;

    using RSSFeed.Data.Models.Contracts;

    public interface IPersonalFeedsService
    {
        IQueryable<IPersonalFeed> GetPersonalFeedsByUserId(string userId);

    }
}
