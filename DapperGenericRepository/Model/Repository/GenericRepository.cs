using Dapper;
using DapperGenericRepository.Model.Context;

namespace DapperGenericRepository.Model.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DapperContext _context;
        private readonly string _tableName;
        private readonly List<string> _columnNames;

        public GenericRepository(DapperContext context)
        {
            _context = context;
            _tableName = typeof(T).Name + "s";
            _columnNames = typeof(T).GetProperties().Where(p => p.Name != "Id").Select(p => p.Name).ToList();
        }

        public async Task<bool> InsertAsync(T model)
        {
            var query = $"INSERT INTO {_tableName} ({string.Join(',', _columnNames)}) VALUES (@{string.Join(", @", _columnNames)})";

            using (var connection = _context.CreateConnection())
            {
                var result  = await connection.ExecuteAsync(query, model);
                return result > 0;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var query = $"SELECT * FROM {_tableName}";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<T>(query);
                return result;
            }
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            var query = $"SELECT * FROM {_tableName} WHERE id = {id}";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QuerySingleOrDefaultAsync<T>(query);
                return result;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var query = $"DELETE FROM {_tableName} WHERE id = {id}";      

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.ExecuteAsync(query);
                return result > 0;
            }
        }

        public async Task<bool> UpdateAsync(T model)
        {
            var setValues = _columnNames.Select(prop => $"{prop} = @{prop}");

            var query = $"UPDATE {_tableName} SET {string.Join(", ", setValues)} WHERE id = @Id";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.ExecuteAsync(query, model);
                return result > 0;
            }
        }
    }
}
