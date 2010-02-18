using System.Linq;

namespace ScheduMail.Core.RepositoryInterfaces
{
    /// <summary>
    /// Provides a standard interface for CRUD operations
    /// </summary>
    /// <typeparam name="T">Domain Data Transfer Object type.</typeparam>
    /// <typeparam name="IdT">The type of the d T.</typeparam>
    public interface ICrudRepository<T, IdT>
    {
        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <value>The list value returned.</value>
        IQueryable<T> List { get; }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The key value identification.</param>
        /// <returns>Found instance.</returns>
        T GetById(IdT id);

        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Saved instance.</returns>
        T Save(T entity);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="originalEntity">The original entity.</param>
        /// <returns>Updated instance.</returns>
        T Update(T entity, T originalEntity);
        
        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(T entity);
    }
}
