
namespace DapperGenericRepository.Model.Repository
{
    /// <summary>
    /// Represents a generic repository for managing entities of type T using Dapper.
    /// </summary>
    /// <typeparam name="T">The type of entities managed by the repository.</typeparam>
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Asynchronously retrieves a record from the database table by its ID.
        /// </summary>
        /// <param name="id">The ID of the record to retrieve.</param>
        /// <returns>The record with the specified ID, or null if not found.</returns>
        Task<T?> GetByIdAsync(int id);

        /// <summary>
        /// Asynchronously retrieves all records from the database table.
        /// </summary>
        /// <returns>An IEnumerable collection of all records.</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Asynchronously inserts a new record into the database table and returns the generated identifier.
        /// </summary>
        /// <param name="model">The model containing the data to be inserted.</param>
        /// <returns>An integer representing the identifier of the newly inserted record, or 0 if the insertion failed.</returns>
        Task<int> InsertAsync(T model);

        /// <summary>
        /// Asynchronously updates the specified record in the database table.
        /// </summary>
        /// <param name="model">The model object containing updated data.</param>
        /// <returns>True if the update is successful, otherwise false.</returns>
        Task<bool> UpdateAsync(T model);

        /// <summary>
        /// Asynchronously deletes a record from the database table.
        /// </summary>
        /// <param name="id">The ID of the record to delete.</param>
        /// <returns>True if the record is successfully deleted, otherwise false.</returns>
        Task<bool> DeleteAsync(int id);
    }
}