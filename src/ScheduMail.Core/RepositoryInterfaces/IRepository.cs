using System.Linq;

namespace ScheduMail.Core.RepositoryInterfaces
{
    /// <summary>
    /// Provides a standard interface for CRUD operations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="IdT">The type of the d T.</typeparam>
    public interface ICrudRepository<T, IdT>
    {
        IQueryable<T> List { get; }
        T GetById(IdT id);
        T Save(T entity);
        T Update(T entity, T originalEntity);
        void Delete(T entity);
    }
}
