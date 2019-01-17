using RSSFeed.Data.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSFeed.Data.Models
{
    public class Feed : IDeletableEntity
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

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
