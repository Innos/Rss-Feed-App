namespace RssFeed.Services.PersonalCategories
{
    using System.Linq;

    using RssFeed.Data.Models;
    using RssFeed.Data.Models.Contracts;
    using RssFeed.Data.Repositories.Contracts;

    public class PersonalCategoriesService : IPersonalCategoriesService
    {
        protected IDeletableEntityRepository<PersonalCategory> PersonalCategories;

        public PersonalCategoriesService(IDeletableEntityRepository<PersonalCategory> personalCategoriesRepository)
        {
            this.PersonalCategories = personalCategoriesRepository;
        }

        public PersonalCategory GetByNameAndUser(string personalCategoryName, string userId)
        {
            return
                this.PersonalCategories
                    .All()
                    .FirstOrDefault(pc => pc.Name == personalCategoryName && pc.UserId == userId);
        }

        public IQueryable<PersonalCategory> GetByUser(string userId)
        {
            return this.PersonalCategories.All().Where(pc => pc.UserId == userId);
        }
    }
}
