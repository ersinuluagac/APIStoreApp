using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryBase<T>
    {
        /// <summary>
        /// Retrieves all entities of type T.
        /// </summary>
        /// <param name="trackChanges">Whether to track entity changes.</param>
        /// <returns>A queryable collection of all entities.</returns>
        IQueryable<T> FindAll(bool trackChanges);
        /// <summary>
        /// Retrieves entities of type T that match the specified condition.
        /// </summary>
        /// <param name="expression">The condition expression used to filter entities.</param>
        /// <param name="trackChanges">Whether to track entity changes.</param>
        /// <returns>A queryable collection of filtered entities.</returns>
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        /// <summary>
        /// Creates a new entity of type T.
        /// </summary>
        /// <param name="entity">The entity to be added.</param>
        void Create(T entity);
        /// <summary>
        /// Updates an existing entity of type T.
        /// </summary>
        /// <param name="entity">The entity to be updated.</param>
        void Update(T entity);
        /// <summary>
        /// Deletes an entity of type T.
        /// </summary>
        /// <param name="entity">The entity to be deleted.</param>
        void Delete(T entity);
    }
}
