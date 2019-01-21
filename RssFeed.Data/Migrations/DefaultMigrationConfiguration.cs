namespace RssFeed.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class DefaultMigrationConfiguration : DbMigrationsConfiguration<RssFeedDbContext>
    {
        public DefaultMigrationConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(RssFeedDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
