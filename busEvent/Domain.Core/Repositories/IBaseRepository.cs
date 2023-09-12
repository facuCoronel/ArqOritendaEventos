using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(object id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
        void Commit();
        void LoadReference(TEntity obj, Expression<Func<TEntity, object>> reference);
        void LoadCollection(TEntity obj, Expression<Func<TEntity, IEnumerable<object>>> collection);
        IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<T> Filter<T>(Func<T, bool> predicate) where T : class, Domain.Core.Interfaces.IEntity;
        IQueryable<T> ForFilter<T>(Expression<Func<T, bool>> predicate = null) where T : class, Domain.Core.Interfaces.IEntity;
        IEnumerable<T> DoFilter<T>(Func<T, bool> predicate = null) where T : class, Domain.Core.Interfaces.IEntity;
        void Update<T>(T obj);
        void Remove<T>(T obj) where T : class, Domain.Core.Interfaces.IEntity;
        void Add<T>(T obj) where T : class, Domain.Core.Interfaces.IEntity;
        T GetById<T>(object id) where T : class, Domain.Core.Interfaces.IEntity;
        IEnumerable<T> GetAll<T>() where T : class, Domain.Core.Interfaces.IEntity;
        IEnumerable<T> GetAllAsNoTracking<T>() where T : class, Domain.Core.Interfaces.IEntity;
    }
}
