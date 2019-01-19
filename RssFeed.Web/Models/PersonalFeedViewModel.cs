namespace RssFeed.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using RSSFeed.Data.Models;

    public class PersonalFeedViewModel
    {
        public PersonalFeedViewModel()
        {
            //this.unreadArticles = new HashSet<UnreadArticle>();
        }

        [HiddenInput(DisplayValue = false)]
        public long Id { get; set; }


        [Display(Name = "Категория")]
        public long CategoryId { get; set; }

        //[UIHint("DropDownList")]
        //public virtual Category Category { get; set; }

        //public long FeedId { get; set; }

        //public virtual Feed Feed { get; set; }

        [Display(Name = "Rss Feed адрес")]
        [Required(ErrorMessage = "Адресът на Rss Feed-a е задължителен!")]
        [Url]
        public string RssFeedUrl { get; set; }
    }
}