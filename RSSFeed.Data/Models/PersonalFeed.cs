using RSSFeed.Data.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSFeed.Data.Models
{
    public class PersonalFeed : IDeletableEntity
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

        public virtual Category Category { get; set; }

        [Required]
        public long FeedId { get; set; }

        public virtual Feed Feed { get; set; }

        public int LastKnownArticleId { get; set; }

        public virtual ICollection<UnreadArticle> UnreadArticles { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
