using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RssFeed.Data.Repositories.Contracts
{
    public interface IRepository<T>
        where T : class
    {
        IQueryable<T> All();

        T GetById(params object[] id);

        Task<T> GetByIdAsync(params object[] id);

        void Add(T entity);

        void Update(T entity);

        int Update(Expression<Func<T, bool>> filterExpression, Expression<Func<T, T>> updateExpression);

        void Delete(T entity);

        void Delete(params object[] id);

        int Delete(Expression<Func<T, bool>> filterExpression);

        void Detach(T entity);

        int SaveChanges();
    }
}
