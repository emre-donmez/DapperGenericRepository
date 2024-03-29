
namespace DapperGenericRepository.Model.Repository
{
    /// <summary>
    /// Represents a generic repository for managing entities of type T using Dapper.
    /// </summary>
    /// <typeparam name="T">The type of entities managed by the repository.</typeparam>
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Retrieves a record from the database table by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the record to retrieve.</param>
        /// <returns>The record with the specified ID, or null if not found.</returns>
        Task<T?> GetByIdAsync(int id);

        /// <summary>
        /// Retrieves all records from the database table asynchronously.
        /// </summary>
        /// <returns>An IEnumerable collection of all records.</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Inserts the given model object into the database asynchronously.
        /// </summary>
        /// <param name="model">The model object to be inserted.</param>
        /// <returns>True if the insertion is successful, otherwise false.</returns>
        Task<bool> InsertAsync(T model);

        /// <summary>
        /// Updates the specified record in the database table asynchronously.
        /// </summary>
        /// <param name="model">The model object containing updated data.</param>
        /// <returns>True if the update is successful, otherwise false.</returns>
        Task<bool> UpdateAsync(T model);

        /// <summary>
        /// Deletes a record from the database table asynchronously.
        /// </summary>
        /// <param name="id">The ID of the record to delete.</param>
        /// <returns>True if the record is successfully deleted, otherwise false.</returns>
        Task<bool> DeleteAsync(int id);
    }
}