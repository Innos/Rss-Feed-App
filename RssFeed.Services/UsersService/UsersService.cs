namespace RssFeed.Services.UsersService
{
    using System.Linq;

    using RssFeed.Data.Models.Contracts;
    using RssFeed.Data.Repositories.Contracts;

    public class UsersService<TUser> : IUsersService<TUser>
        where TUser : class, IUser, new()
    {
        protected IDeletableEntityRepository<TUser> Users { get; }

        public UsersService(IDeletableEntityRepository<TUser> usersRepository)
        {
            this.Users = usersRepository;
        }

        public IQueryable<TUser> GetUserByIdQuery(string userId)
        {
            return this.Users.All().Where(x => x.Id == userId);
        }

        public TUser GetUserByUsername(string username)
        {
            return this.Users.All().FirstOrDefault(x => x.UserName == username);
        }
    }
}
