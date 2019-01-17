using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSFeed.Data.Models
{
    using System.Security.Claims;

    using Microsoft.AspNet.Identity;

    public class User : IdentityUser
    {
        private ICollection<ActivityLog> activityLogs;

        public User(string userName) : base(userName)
        {
            this.IsActive = true;
            this.activityLogs = new HashSet<ActivityLog>();
        }

        public User() : base()
        {
            this.IsActive = true;
            this.activityLogs = new HashSet<ActivityLog>();
        }

        public bool IsActive { get; set; }
        
        public virtual ICollection<ActivityLog> ActivityLogs
        {
            get { return this.activityLogs; }
            set { this.activityLogs = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
