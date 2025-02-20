using FinanceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Data.Service
{
    public class ExpensesService : IExpensesService
    {
        private readonly FinanceAppContext _context;

        public ExpensesService(FinanceAppContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Expense>> GetAll()
        {
            return await _context.Expenses.ToListAsync();
        }

        public async Task Add(Expense expense)
        {
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItem(int id)
        {
            var item = await _context.Expenses.FirstOrDefaultAsync(i => i.Id == id);
            if (item != null)
            {
                _context.Expenses.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public IQueryable GetChartData()
        {
            return _context.Expenses
                .GroupBy(e => e.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    Total = g.Sum(e => e.Amount),
                });
        }

        public async Task<Expense> GetById(int id) 
        {
            return await _context.Expenses.FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
