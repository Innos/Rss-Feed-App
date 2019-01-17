using RSSFeed.Data.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RSSFeed.Data.Repositories.Contracts
{
    public interface IDeletableEntityRepository<T> : IRepository<T>
        where T : class, IDeletableEntity
    {
        IQueryable<T> AllWithDeleted();

        void Undelete(T entity);

        void Undelete(params object[] id);

        int Undelete(Expression<Func<T, bool>> filterExpression);
    }
}
