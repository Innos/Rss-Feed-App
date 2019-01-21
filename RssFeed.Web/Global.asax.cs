namespace RssFeed.Web
{
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using RssFeed.Data;
    using RssFeed.Data.Migrations;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<RssFeedDbContext, DefaultMigrationConfiguration>());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.RegisterMappings();
            SimpleInjectorConfig.RegisterDependencyInjection();
        }
    }
}
