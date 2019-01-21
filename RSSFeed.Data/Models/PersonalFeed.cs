namespace RssFeed.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using RssFeed.Data.Models.Common;
    using RssFeed.Data.Models.Contracts;

    public class PersonalFeed : DeletableEntity, IPersonalFeed
    {
        private ICollection<UnreadArticle> unreadArticles;

        public PersonalFeed()
        {
            this.LastKnownArticleId = 0;
            this.unreadArticles = new HashSet<UnreadArticle>();
        }

        [Key]
        public long Id { get; set; }

        //[Required]
        //public string UserId { get; set; }

        //public virtual User User { get; set; }

        [Required]
        public long CategoryId { get; set; }

        public virtual PersonalCategory Category { get; set; }

        [Required]
        public long FeedId { get; set; }

        public virtual Feed Feed { get; set; }

        public int LastKnownArticleId { get; set; }

        public virtual ICollection<UnreadArticle> UnreadArticles { get; set; }


    }
}
