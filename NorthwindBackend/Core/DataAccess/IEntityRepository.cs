using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Entities;
using Core.Entities.Concrete;
using Entities.Concrete;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> id);

        IList<T> GetList(Expression<Func<T, bool>> filter = null);

        IList<T> GetUser(Expression<Func<T, bool>> filter = null);
        IList<T> GetEtkinlikFirma(Expression<Func<T, bool>> filter = null);

        void AddEtkinlik(Etkinlik entity);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

    }
}
