using CursoBlazor.Models;
using Dapper;
using System.Data.SqlClient;

namespace CursoBlazor.Data.Repositories
{
    public class CategoriaRepo : ICategoryRepo
    {
        private SqlConfiguration _sqlConfiguration;

        public CategoriaRepo(SqlConfiguration sqlConfiguration)
        {
            _sqlConfiguration = sqlConfiguration;
        }

        protected SqlConnection DbConnection() => new(_sqlConfiguration.ConnectionString);

        public async Task<bool> DeleteCategoria(int id)
        {
            var db = DbConnection();
            var sql = "DELETE Categoria WHERE Id = @Id";
            var result = await db.ExecuteAsync(sql, new { Id = id });
            return result > 0;
        }

        public async Task<Categoria> GetCategoria(int id)
        {
            var db = DbConnection();
            var sql = "SELECT [Id], [Name] FROM [dbo].[Categoria] WHERE [Id] = @Id";
            return await db.QueryFirstOrDefaultAsync<Categoria>(sql, new { Id = id });
        }

        public async Task<IEnumerable<Categoria>> GetCategorias()
        {
            var db = DbConnection();
            var sql = "SELECT [Id], [Name] FROM [dbo].[Categoria]";
            return await db.QueryAsync<Categoria>(sql, new { });
        }

        public async Task<bool> InsertCategoria(Categoria categoria)
        {
            var db = DbConnection();
            var sql = "INSERT INTO Categoria(Name) VALUES(@Name)";
            var result = await db.ExecuteAsync(sql, new { categoria.Name });
            return result > 0;
        }

        public async Task<bool> UpdateCategoria(Categoria categoria)
        {
            var db = DbConnection();
            var sql = "UPDATE Categoria SET Name = @Name WHERE Id = @Id";
            var result = await db.ExecuteAsync(sql, new { categoria.Name, categoria.Id });
            return result > 0;
        }
    }
}
