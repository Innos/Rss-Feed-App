namespace RssFeed.Services.Feeds
{
    using RssFeed.Data.Models;

    public interface IFeedsService
    {
        Feed GetByUrl(string url);

        bool ExistsByUrl(string url);
    }
}
