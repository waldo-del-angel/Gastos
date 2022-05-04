using CursoBlazor.Models;
using Dapper;
using System.Data.SqlClient;

namespace CursoBlazor.Data.Repositories
{
    public class ExpenseRepo : IExpenseRepo
    {
        private SqlConfiguration _sqlConfiguration;

        public ExpenseRepo(SqlConfiguration sqlConfiguration)
        {
            _sqlConfiguration = sqlConfiguration;
        }

        protected SqlConnection DbConnection() => new(_sqlConfiguration.ConnectionString);

        public async Task<bool> DeleteExpense(int id)
        {
            var db = DbConnection();
            var sql = "DELETE Gasto WHERE Id = @Id";
            var result = await db.ExecuteAsync(sql, new { Id = id });
            return result > 0;
        }

        public async Task<Expense> GetExpense(int id)
        {
            var db = DbConnection();
            var sql = "SELECT * FROM Gasto WHERE Id = @Id";
            return await db.QueryFirstOrDefaultAsync<Expense>(sql, new { Id = id }); 
        }

        public async Task<IEnumerable<Expense>> GetExpenses()
        {
            var db = DbConnection();
            var sql = @"
                SELECT
                    A.*,
                    B.*
                FROM Gasto A
                JOIN Categoria B ON A.IdCategoria = c.Id";

            var result = await db.QueryAsync<Expense, Categoria, Expense>(sql, (expense, category) =>
            {
                expense.Categoria = category;
                return expense;
            }, new { }, splitOn: "Id");

            return result;
        }

        public async Task<bool> InsertExpense(Expense expense)
        {
            var db = DbConnection();
            var sql = "INSERT INTO Casto(Cantidad, IdCategoria, TipoGasto, FechaTransacción" +
                   ") VALUES(@Cantidad, @IdCategoria, @TipoGasto, @FechaTransaccion)";
            var result = await db.ExecuteAsync(sql, new { expense.Cantidad, expense.IdCategoria, expense.TipoGasto, expense.FechaTransaccion });
            return result > 0;
        }

        public async Task<bool> UpdateExpense(Expense expense)
        {
            var db = DbConnection();
            var sql = "UPDATE Gasto SET Cantidad = @Name WHERE Id = @Id";
            var result = await db.ExecuteAsync(sql, new { expense.Id, expense.Cantidad, expense.IdCategoria, expense.TipoGasto, expense.FechaTransaccion});
            return result > 0;
        }
    }
}
