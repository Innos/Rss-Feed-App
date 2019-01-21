namespace RssFeed.Services.PersonalFeedsService
{
    using System.Linq;

    using RssFeed.Data.Models;

    public interface IPersonalFeedsService
    {
        IQueryable<PersonalFeed> GetPersonalFeedsByUserId(string userId);

    }
}
