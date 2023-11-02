using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Repositories
{
    public class UserRepository
    {
        private readonly FPDbContext _context;

        public UserRepository(FPDbContext context)
        {
            _context = context;
        }

        public bool CheckUserCredentials(string username, string password)
        {
            return _context.Users.Any(u => u.Username == username && u.Password == password);
        }

        public void AddUser(string username, string email, string password)
        {
            var newUser = new User { Username = username, Email = email, Password = password };
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

        public int GetUserIdByUsername(string username)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            return user?.UserId ?? -1;
        }
    }
    public class CategoryRepository
    {
        private readonly FPDbContext _context;

        public CategoryRepository(FPDbContext context)
        {
            _context = context;
        }

        public List<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public Dictionary<int, string> GetCategoriesIdAndName()
        {
            return _context.Categories.ToDictionary(c => c.CategoryId, c => c.CategoryName);
        }
    }
    public class IncomeRepository
    {
        private readonly FPDbContext _context;

        public IncomeRepository(FPDbContext context)
        {
            _context = context;
        }

        public void AddIncomeForUser(int userId, decimal incomeSum)
        {
            var newIncome = new Income { UserId = userId, IncomeSum = incomeSum };
            _context.Incomes.Add(newIncome);
            _context.SaveChanges();
        }
    }

    public class ExpenseRepository
    {
        private readonly FPDbContext _context;

        public ExpenseRepository(FPDbContext context)
        {
            _context = context;
        }

        public void AddExpenseForUser(int userId, int categoryId, decimal expenseSum)
        {
            var newExpense = new Expense { UserId = userId, CategoryId = categoryId, ExpenseSum = expenseSum };
            _context.Expenses.Add(newExpense);
            _context.SaveChanges();
        }
    }

    public class CategorySumRepository
    {
        private readonly FPDbContext _context;

        public CategorySumRepository(FPDbContext context)
        {
            _context = context;
        }

        public List<CategorySum> GetCategorySumsForUser(int userId)
        {
            return _context.CategorySums.Where(cs => cs.UserId == userId).ToList();
        }
    }

    public class UserBudgetRepository
    {
        private readonly FPDbContext _context;

        public UserBudgetRepository(FPDbContext context)
        {
            _context = context;
        }

        public UserBudget GetUserBudget(int userId)
        {
            var userBudget = _context.UserBudgets.FirstOrDefault(ub => ub.UserId == userId);
            return userBudget;
        }
    }
}
