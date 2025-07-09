using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
        /// <summary>
        /// Retrieves all books asynchronously.
        /// </summary>
        /// <param name="trackChanges">Whether to track entity changes.</param>
        /// <returns>An enumerable collection of all books.</returns>
        Task<IEnumerable<Book>> GetAllBooksAsync(bool trackChanges);
        /// <summary>
        /// Retrieves a single book by its ID asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the book.</param>
        /// <param name="trackChanges">Whether to track entity changes.</param>
        /// <returns>The book with the specified ID, or null if not found.</returns>
        Task<Book> GetOneBookByIdAsync(int id, bool trackChanges);
        /// <summary>
        /// Creates a new book.
        /// </summary>
        /// <param name="book">The book entity to be created.</param>
        void CreateOneBook(Book book);
        /// <summary>
        /// Updates an existing book.
        /// </summary>
        /// <param name="book">The book entity to be updated.</param>
        void UpdateOneBook(Book book);
        /// <summary>
        /// Deletes a book.
        /// </summary>
        /// <param name="book">The book entity to be deleted</param>
        void DeleteOneBook(Book book);
    }
}
