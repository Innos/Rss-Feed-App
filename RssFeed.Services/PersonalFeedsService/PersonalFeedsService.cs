namespace RssFeed.Services.PersonalFeedsService
{
    using System.Linq;

    using RSSFeed.Data.Models.Contracts;
    using RSSFeed.Data.Repositories.Contracts;

    public class PersonalFeedsService : IPersonalFeedsService
    {
        protected IDeletableEntityRepository<IPersonalFeed> PersonalFeeds { get; }

        public PersonalFeedsService(
            IDeletableEntityRepository<IPersonalFeed> personalFeedsRepository)
        {
            this.PersonalFeeds = personalFeedsRepository;
        }

        public IQueryable<IPersonalFeed> GetPersonalFeedsByUserId(string userId)
        {
            return this.PersonalFeeds.All().Where(pf => pf.Category.UserId == userId);
        }
    }
}
