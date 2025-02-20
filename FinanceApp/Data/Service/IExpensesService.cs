using FinanceApp.Models;

namespace FinanceApp.Data.Service
{
    public interface IExpensesService
    {
        Task<IEnumerable<Expense>> GetAll();
        Task Add(Expense expense);

        Task DeleteItem(int id);
         IQueryable GetChartData();
        Task<Expense> GetById(int id);

    }
}
