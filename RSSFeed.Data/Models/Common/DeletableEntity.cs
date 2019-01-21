namespace RssFeed.Data.Models.Common
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using RssFeed.Data.Models.Contracts.Common;

    public class DeletableEntity : IDeletableEntity
    {
        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
