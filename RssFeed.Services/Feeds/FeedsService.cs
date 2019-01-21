namespace RssFeed.Services.Feeds
{
    using System.Linq;

    using RssFeed.Data.Models;
    using RssFeed.Data.Repositories.Contracts;

    public class FeedsService : IFeedsService
    {
        protected IDeletableEntityRepository<Feed> Feeds { get; set; }

        public FeedsService(IDeletableEntityRepository<Feed> feedsRepository)
        {
            this.Feeds = feedsRepository;
        }

        public Feed GetByUrl(string url)
        {
            return this.Feeds.All().FirstOrDefault(f => f.Url == url);
        }

        public bool ExistsByUrl(string url)
        {
            return this.Feeds.All().Any(f => f.Url == url);
        }
    }
}
