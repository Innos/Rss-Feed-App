namespace RssFeed.Services.PersonalFeedsService
{
    using System.Linq;

    using RssFeed.Data.Models;
    using RssFeed.Data.Models.Contracts;
    using RssFeed.Data.Repositories.Contracts;

    public class PersonalFeedsService : IPersonalFeedsService
    {
        protected IDeletableEntityRepository<PersonalFeed> PersonalFeeds { get; }

        public PersonalFeedsService(
            IDeletableEntityRepository<PersonalFeed> personalFeedsRepository)
        {
            this.PersonalFeeds = personalFeedsRepository;
        }

        public IQueryable<PersonalFeed> GetPersonalFeedsByUserId(string userId)
        {
            return this.PersonalFeeds.All().Where(pf => pf.Category.UserId == userId);
        }
    }
}
