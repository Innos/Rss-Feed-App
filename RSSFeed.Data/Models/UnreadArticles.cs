using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSFeed.Data.Models
{
    public class UnreadArticle
    {
        public UnreadArticle(int articleId)
        {
            this.ArticleId = articleId;
        }

        [Key]
        [Column(Order = 0)]
        [Required]
        public int PersonalFeedId { get; set; }

        public virtual PersonalFeed PersonalFeed { get; set; }

        [Key]
        [Column(Order = 1)]
        public int ArticleId { get; set; }
    }
}
