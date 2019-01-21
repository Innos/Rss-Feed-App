namespace RssFeed.Data.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    using RssFeed.Data.Repositories.Contracts;
    using RssFeed.Data.Models.Contracts.Common;

    using Z.EntityFramework.Plus;

    public class DeletableEntityRepository<T> : Repository<T>, IDeletableEntityRepository<T>
            where T : class, IDeletableEntity, new()
    {
        public DeletableEntityRepository(DbContext context)
            : base(context)
        {
        }

        public override IQueryable<T> All() => base.All().Where(x => !x.IsDeleted);

        public IQueryable<T> AllWithDeleted() => base.All();

        public override void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;
            this.Update(entity);
        }

        public override void Delete(params object[] id)
        {
            var entity = this.GetById(id);
            this.Delete(entity);
        }

        public override int Delete(Expression<Func<T, bool>> filterExpression) =>
            this.DbSet.Where(filterExpression).Update(x => new T { IsDeleted = true, DeletedOn = DateTime.Now });

        public void Undelete(T entity)
        {
            entity.IsDeleted = false;
            entity.DeletedOn = null;
            this.Update(entity);
        }

        public void Undelete(params object[] id)
        {
            var entity = this.GetById(id);
            this.Undelete(entity);
        }

        public int Undelete(Expression<Func<T, bool>> filterExpression) =>
            this.DbSet.Where(filterExpression).Update(x => new T { IsDeleted = false, DeletedOn = null });
    }
}
