using RSSFeed.Data.Models;
using RSSFeed.Data.Models.Contracts;
using RSSFeed.Data.Repositories;
using RSSFeed.Data.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSFeed.Data
{
    public class RssFeedData
    {
        private readonly IDictionary<Type, object> repositories = new Dictionary<Type, object>();

        public RssFeedData(DbContext context)
        {
            this.Context = context;
        }

        public DbContext Context { get; set; }

        public void Dispose()
        {
            this.Context?.Dispose();
        }

        public IRepository<ActivityLog> ActivityLogs => this.GetRepository<ActivityLog>();

        public IDeletableEntityRepository<Category> Categories => this.GetDeletableEntityRepository<Category>();

        public IDeletableEntityRepository<Feed> Feeds => this.GetDeletableEntityRepository<Feed>();

        public IDeletableEntityRepository<PersonalFeed> PersonalFeed => this.GetDeletableEntityRepository<PersonalFeed>();

        public IRepository<UnreadArticle> UnreadArticles => this.GetRepository<UnreadArticle>();

        public int SaveChanges() => this.Context.SaveChanges();

        private IRepository<T> GetRepository<T>()
            where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(Repository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.Context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }

        private IDeletableEntityRepository<T> GetDeletableEntityRepository<T>()
            where T : class, IDeletableEntity, new()
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(DeletableEntityRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.Context));
            }

            return (IDeletableEntityRepository<T>)this.repositories[typeof(T)];
        }
    }
}
