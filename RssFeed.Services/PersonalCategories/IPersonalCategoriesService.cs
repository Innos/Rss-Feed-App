namespace RssFeed.Services.PersonalCategories
{
    using System.Linq;

    using RssFeed.Data.Models;
    using RssFeed.Data.Models.Contracts;

    public interface IPersonalCategoriesService
    {
        PersonalCategory GetByNameAndUser(string personalCategoryName, string userId);

        IQueryable<PersonalCategory> GetByUser(string userId);
    }
}
