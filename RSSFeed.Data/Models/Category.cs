using RSSFeed.Data.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSFeed.Data.Models
{
    public class Category : IDeletableEntity
    {
        public Category()
        {
            this.SubCategories = new HashSet<Category>();
        }

        [Key]
        public long Id { get; set; }

        public string Name { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual Category ParentCategory { get; set; }

        public virtual ICollection<Category> SubCategories { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
