using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssFeed.Services.UsersService
{
    using RSSFeed.Data.Models.Contracts;
    using RSSFeed.Data.Repositories.Contracts;

    public class UsersService<TUser> : IUsersService<TUser>
        where TUser : class, IUser, new()
    {
        protected IDeletableEntityRepository<TUser> Users { get; }
    }
}
