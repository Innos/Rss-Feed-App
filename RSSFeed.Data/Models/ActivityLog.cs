using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssFeed.Data.Models
{
    public class ActivityLog
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
