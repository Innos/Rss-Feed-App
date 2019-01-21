namespace RssFeed.Web.Controllers
{
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;

    using RssFeed.Services.UsersService;

    using RssFeed.Data.Models;

    [Authorize]
    public abstract class BaseAuthorizedController : Controller
    {
        protected User UserProfile { get; private set; }

        protected IUsersService<User> Users;

        public BaseAuthorizedController(IUsersService<User> usersService)
        {
            this.Users = usersService;
        }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            this.UserProfile = this.Users.GetUserByUsername(requestContext.HttpContext.User.Identity.Name);
            return base.BeginExecute(requestContext, callback, state);
        }
    }
}