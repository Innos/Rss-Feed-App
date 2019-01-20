namespace RssFeed.Services.PersonalCategories
{
    using RSSFeed.Data.Models.Contracts;

    public interface IPersonalCategoriesService
    {
        IPersonalCategory GetByNameAndUser(string personalCategoryName, string userId);
    }
}
