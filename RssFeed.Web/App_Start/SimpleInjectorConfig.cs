using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RssFeed.Web
{
    using System.CodeDom;
    using System.Data.Entity;
    using System.Reflection;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Owin;
    using Microsoft.Owin.Security;

    using RssFeed.Services.Feeds;
    using RssFeed.Services.PersonalCategories;
    using RssFeed.Services.PersonalFeedsService;
    using RssFeed.Services.UsersService;

    using RssFeed.Data;
    using RssFeed.Data.Models;
    using RssFeed.Data.Repositories;
    using RssFeed.Data.Repositories.Contracts;

    using SimpleInjector;
    using SimpleInjector.Advanced;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;

    public class SimpleInjectorConfig
    {
        public static Container Container { get; private set; }

        public static void RegisterDependencyInjection()
        {
            // Create the container as usual.
            Container = new Container();
            Container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Register your types, for instance:

            // Common types
            Container.Register<DbContext>(() => new RssFeedDbContext(), Lifestyle.Scoped);
            Container.Register(typeof(IRepository<>), typeof(Repository<>), Lifestyle.Scoped);
            Container.Register(typeof(IDeletableEntityRepository<>), typeof(DeletableEntityRepository<>), Lifestyle.Scoped);

            // Identity
            Container.Register(
                () => Container.IsVerifying()
                    ? new OwinContext(new Dictionary<string, object>()).Authentication
                    : HttpContext.Current.GetOwinContext().Authentication,
                Lifestyle.Scoped);
            //Container.Register(() => HttpContext.Current.GetOwinContext().Authentication, Lifestyle.Scoped);
            Container.Register<IUserStore<User>>(() => new UserStore<User>(Container.GetInstance<DbContext>()),Lifestyle.Scoped);
            Container.Register<ApplicationUserManager>(Lifestyle.Scoped);
            Container.Register<ApplicationSignInManager>(Lifestyle.Scoped);

            //Container.Register(
            //    () => new ApplicationUserManager(new UserStore<User>(Container.GetInstance<DbContext>())),
            //    Lifestyle.Scoped);


            //var personalCategoriesService =
            //    Lifestyle.Scoped.CreateRegistration(
            //        () => new PersonalCategoriesService(
            //            container.GetInstance<IDeletableEntityRepository<PersonalCategory>>()), container);
            //container.AddRegistration(typeof(IPersonalCategoriesService), personalCategoriesService);

            //var personalFeedsService =
            //    Lifestyle.Scoped.CreateRegistration(
            //        () => new PersonalFeedsService(
            //            container.GetInstance<IDeletableEntityRepository<PersonalFeed>>()), container);
            //container.AddRegistration(typeof(IPersonalFeedsService), personalFeedsService);

            Container.Register<IUsersService<User>>(
                () => new UsersService<User>(Container.GetInstance<IDeletableEntityRepository<User>>()),
                Lifestyle.Scoped);

            Container.Register<IPersonalCategoriesService>(
                () => new PersonalCategoriesService(Container.GetInstance<IDeletableEntityRepository<PersonalCategory>>()),
                Lifestyle.Scoped);
            Container.Register<IPersonalFeedsService>(
                () => new PersonalFeedsService(Container.GetInstance<IDeletableEntityRepository<PersonalFeed>>()),
                Lifestyle.Scoped);
            Container.Register<IFeedsService>(
                () => new FeedsService(Container.GetInstance<IDeletableEntityRepository<Feed>>()),
                Lifestyle.Scoped);

            // This is an extension method from the integration package.
            Container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            Container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(Container));
        }  
    }
}