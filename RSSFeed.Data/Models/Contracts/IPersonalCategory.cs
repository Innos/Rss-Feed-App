namespace RSSFeed.Data.Models.Contracts
{
    using System.Collections.Generic;

    using RSSFeed.Data.Models.Contracts.Common;

    public interface IPersonalCategory : IDeletableEntity
    {
        long Id { get; set; }

        string Name { get; set; }

        string UserId { get; set; }

        User User { get; set; }

        PersonalCategory ParentCategory { get; set; }

        ICollection<PersonalCategory> SubCategories { get; set; }
    }
}
