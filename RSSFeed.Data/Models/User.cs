namespace RSSFeed.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using IUser = RSSFeed.Data.Models.Contracts.IUser;

    public class User : IdentityUser, IUser
    {
        private ICollection<ActivityLog> activityLogs;

        public User(string userName) : base(userName)
        {
            this.IsActive = true;
            this.activityLogs = new HashSet<ActivityLog>();
            this.PersonalCategories = new HashSet<PersonalCategory>();
        }

        public User()
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

        public ICollection<PersonalCategory> PersonalCategories { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
