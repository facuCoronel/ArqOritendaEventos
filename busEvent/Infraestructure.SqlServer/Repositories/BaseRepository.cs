using Domain.Core;
using Domain.Core.Repositories;
using Infraestructure.SqlServer.EventsDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.SqlServer.Repositories
{
    public class BaseRepository<TEntity> : IDisposable, IBaseRepository<TEntity>
        where TEntity : class
    {
        private readonly EventDbContext _db;

        public BaseRepository(EventDbContext db)
        {
            _db = db;
        }

        public void Add(TEntity obj)
        {
            _db.Set<TEntity>().Add(obj);
        }

        public void LoadReference(TEntity obj, Expression<Func<TEntity, object>> reference)
        {
            if (!_db.Entry(obj).Reference(reference).IsLoaded)
                _db.Entry(obj).Reference(reference).Load();
        }

        public void LoadCollection(TEntity obj, Expression<Func<TEntity, IEnumerable<object>>> collection)
        {
            if (!_db.Entry(obj).Collection(collection).IsLoaded)
                _db.Entry(obj).Collection(collection).Load();
        }

        public TEntity GetById(object id)
        {
            return _db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _db.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> GetAllAsNoTracking()
        {
            return _db.Set<TEntity>().AsNoTracking().ToList();
        }

        public void Update(TEntity obj)
        {
            _db.Entry(obj).State = EntityState.Modified;
        }

        public void Remove(TEntity obj)
        {
            _db.Set<TEntity>().Remove(obj);
        }

        public IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate)
        {
            return _db.Set<TEntity>().Where(predicate);
        }

        /// <inheritdoc />
        public IEnumerable<T> Filter<T>(Func<T, bool> predicate) where T : class, Domain.Core.Interfaces.IEntity
        {
            return _db.Set<T>().AsEnumerable().Where(predicate);
        }

        public void Commit()
        {
            try
            {
                _db.SaveChanges();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            _db.Dispose();
            //throw new NotImplementedException();
        }

        public IQueryable<T> ForFilter<T>(Expression<Func<T, bool>> predicate = null) where T : class, Domain.Core.Interfaces.IEntity
        {
            return predicate is null
                ? _db.Set<T>()
                : _db.Set<T>().Where(predicate);
        }

        public IEnumerable<T> DoFilter<T>(Func<T, bool> predicate = null) where T : class, Domain.Core.Interfaces.IEntity
        {
            return predicate is null
                ? _db.Set<T>()
                : _db.Set<T>().Where(predicate);
        }

        public void Update<T>(T obj) => _db.Entry(obj).State = EntityState.Modified;
        public void Remove<T>(T obj) where T : class, Domain.Core.Interfaces.IEntity => _db.Set<T>().Remove(obj);
        public void Add<T>(T obj) where T : class, Domain.Core.Interfaces.IEntity => _db.Set<T>().Add(obj);
        public T GetById<T>(object id) where T : class, Domain.Core.Interfaces.IEntity => _db.Set<T>().Find(id);
        public IEnumerable<T> GetAll<T>() where T : class, Domain.Core.Interfaces.IEntity => _db.Set<T>().ToList();
        public IEnumerable<T> GetAllAsNoTracking<T>() where T : class, Domain.Core.Interfaces.IEntity => _db.Set<T>().AsNoTracking().ToList();

    }
}
