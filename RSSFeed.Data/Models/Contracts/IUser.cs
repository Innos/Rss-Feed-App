namespace RSSFeed.Data.Models.Contracts
{
    using System.Collections.Generic;

    using RSSFeed.Data.Models.Contracts.Common;

    public interface IUser : IDeletableEntity
    {
        string Id { get; set; }

        string UserName { get; set; }

        string Email { get; set; }

        bool IsActive { get; set; }

        ICollection<ActivityLog> ActivityLogs { get; }

        ICollection<PersonalCategory> PersonalCategories { get; }
    }
}
