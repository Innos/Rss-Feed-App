namespace RssFeed.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using RssFeed.Data.Models.Common;
    using RssFeed.Data.Models.Contracts;

    public class PersonalCategory : DeletableEntity, IPersonalCategory
    {
        public PersonalCategory()
        {
            this.SubCategories = new HashSet<PersonalCategory>();
        }

        [Key]
        public long Id { get; set; }

        public string Name { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual PersonalCategory ParentCategory { get; set; }

        public virtual ICollection<PersonalCategory> SubCategories { get; set; }
    }
}
