using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduMail.Core.RepositoryInterfaces
{
    public interface ICrudRepository<T, IdT>
    {
        IQueryable<T> List { get; }
        T GetById(IdT id);
        T Save(T entity);
        T Update(T entity, T originalEntity);
        T Update(T entity, T originalEntity, bool attach);
        void Delete(T entity);
    }
}
