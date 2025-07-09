using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        /// <summary>
        /// Provides access to the book repository operations.
        /// </summary>
        IBookRepository Book { get; }

        /// <summary>
        /// Saves all changes made in the context to the database asynchronously.
        /// </summary>
        /// <returns>A Task representing the asynchronous save operation.</returns>
        Task SaveAsync();
    }
}
