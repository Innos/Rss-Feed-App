namespace RssFeed.Web.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class PersonalFeedInputModel
    {
        [HiddenInput(DisplayValue = false)]
        public long Id { get; set; }

        [Display(Name = "Категория")]
        public long CategoryId { get; set; }

        [Display(Name = "Rss Feed адрес")]
        [Required(ErrorMessage = "Адресът на Rss Feed-a е задължителен!")]
        [Url]
        public string Url { get; set; }
    }
}