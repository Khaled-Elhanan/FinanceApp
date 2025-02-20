using FinanceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Data
{
    public class FinanceAppContext :DbContext
    {
        public FinanceAppContext(DbContextOptions<FinanceAppContext>options):
            base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Expense> Expenses { get; set; }
    }
}
