using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using EntityFramework.BulkInsert.Extensions;
using RSSFeed.Data.Repositories.Contracts;
using Z.EntityFramework.Plus;


namespace RSSFeed.Data.Repositories
{
    public class Repository<T> : IRepository<T>
            where T : class
    {
        public Repository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(
                    nameof(context),
                    "An instance of DbContext is required to use this repository.");
            }

            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        protected DbSet<T> DbSet { get; set; }

        protected DbContext Context { get; set; }

        public virtual IQueryable<T> All() => this.DbSet.AsQueryable();

        public virtual T GetById(params object[] id) => this.DbSet.Find(id);

        public Task<T> GetByIdAsync(params object[] id) => this.DbSet.FindAsync(id);

        public virtual void Add(T entity)
        {
            this.DbSet.Add(entity);
        }

        public virtual void BulkInsert(IEnumerable<T> entities)
        {
            this.Context.BulkInsert(entities);
        }

        public virtual void Update(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public virtual int Update(
            Expression<Func<T, bool>> filterExpression,
            Expression<Func<T, T>> updateExpression) =>
            this.DbSet.Where(filterExpression).Update(updateExpression);

        public virtual void Delete(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            this.DbSet.Remove(entity);
        }

        public virtual void Delete(params object[] id)
        {
            var entity = this.GetById(id);
            if (entity != null)
            {
                this.Delete(entity);
            }
        }

        public virtual int Delete(Expression<Func<T, bool>> filterExpression) =>
            this.DbSet.Where(filterExpression).Delete();

        public virtual void Detach(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            entry.State = EntityState.Detached;
        }

        public int SaveChanges() => this.Context.SaveChanges();
    }
}
