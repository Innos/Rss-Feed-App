namespace RSSFeed.Data.Models.Common
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using RSSFeed.Data.Models.Contracts.Common;

    public class DeletableEntity : IDeletableEntity
    {
        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
