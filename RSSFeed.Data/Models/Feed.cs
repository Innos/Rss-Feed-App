namespace RssFeed.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using RssFeed.Data.Models.Common;
    using RssFeed.Data.Models.Contracts;

    public class Feed : DeletableEntity, IFeed
    {
        public Feed() : this (string.Empty)
        {
        }

        public Feed(string url)
        {
            this.ArticlesCount = 0;
            this.Url = url;
        }

        [Key]
        public long Id { get; set; }

        public string Url { get; set; }

        public int ArticlesCount { get; set; }
    }
}
