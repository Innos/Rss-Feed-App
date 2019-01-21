namespace RssFeed.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using RssFeed.Data.Models;

    public class RssFeedDbContext : IdentityDbContext<User>
    {
        // Your context has been configured to use a 'Model1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'RSSFeed.Data.Model1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model1' 
        // connection string in the application configuration file.
        public RssFeedDbContext()
            : base("name=DefaultConnection")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<PersonalCategory> PersonalCategories { get; set; }

        public virtual DbSet<Feed> Feeds { get; set; }

        public virtual DbSet<PersonalFeed> PersonalFeeds { get; set; }

        public virtual DbSet<ActivityLog> ActivityLogs { get; set; }

        public virtual DbSet<UnreadArticle> UnreadArticles { get; set; }

        public static RssFeedDbContext Create() => new RssFeedDbContext();

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Without this call EntityFramework won't be able to configure the identity model
            base.OnModelCreating(modelBuilder);
        }
    }
}