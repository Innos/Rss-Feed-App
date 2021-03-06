﻿namespace RssFeed.Web.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class PersonalFeedViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public long Id { get; set; }

        [Display(Name = "Категория")]
        public string CategoryName { get; set; }

        [Display(Name = "Rss Feed адрес")]
        public string FeedUrl { get; set; }

        [Display(Name = "Брой непрочетени статии")]
        public int UnreadArticlesCount { get; set; }

    }
}