namespace RssFeed.Services.PersonalCategories
{
    using System.Linq;

    using RSSFeed.Data.Models.Contracts;
    using RSSFeed.Data.Repositories.Contracts;

    public class PersonalCategoriesService : IPersonalCategoriesService
    {
        protected IDeletableEntityRepository<IPersonalCategory> PersonalCategories;

        public PersonalCategoriesService(IDeletableEntityRepository<IPersonalCategory> personalCategoriesRepository)
        {
            this.PersonalCategories = personalCategoriesRepository;
        }

        public IPersonalCategory GetByNameAndUser(string personalCategoryName, string userId)
        {
            return
                this.PersonalCategories
                    .All()
                    .FirstOrDefault(pc => pc.Name == personalCategoryName && pc.UserId == userId);
        }
    }
}
