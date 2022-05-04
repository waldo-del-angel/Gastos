using CursoBlazor.Models;

namespace CursoBlazor.Data.Repositories
{
    public interface IExpenseRepo
    {
        Task<IEnumerable<Expense>> GetExpenses();
        Task<Expense> GetExpense(int id);
        Task<bool> InsertExpense(Expense expense);
        Task<bool> UpdateExpense(Expense expense);
        Task<bool> DeleteExpense(int id);
    }
}
