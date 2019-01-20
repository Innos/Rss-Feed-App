﻿namespace RssFeed.Services.UsersService
{
    using System.Linq;

    using RSSFeed.Data.Models.Contracts;

    public interface IUsersService<TUser>
        where TUser : class, IUser, new()
    {
        IQueryable<TUser> GetUserByIdQuery(string userId);

        TUser GetUserByUsername(string username);
    }
}
