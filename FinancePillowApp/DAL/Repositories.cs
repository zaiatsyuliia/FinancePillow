using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DAL.Models;

namespace DAL
{
    public static class UserRepository
    {
        private static FPDbContext context = new FPDbContext();
        public static bool CheckUserCredentials(string email, string password)
        {
            return context.Users.Any(u => u.Email == email && u.Password == password);
        }

        public static bool CheckUserExists(string email)
        {
            return context.Users.Any(u => u.Email == email);
        }


        public static void AddUser(string username, string email, string password)
        {
            var newUser = new User { Username = username, Email = email, Password = password };
            context.Users.Add(newUser);
            context.SaveChanges();
        }

        public static int GetUserIdByEmail( string email)
        {
            var user = context.Users.FirstOrDefault(u => u.Email == email);
            return user?.UserId ?? -1;
        }
        public static string GetUsernameByUserId(int userId)
        {
            var user = context.Users.FirstOrDefault(u => u.UserId == userId);
            return user?.Username ?? "Username";
        }
    }

    public static class CategoryRepository
    {
        private static FPDbContext context = new FPDbContext();
        public static List<Category> GetAllCategories()
        {
            return context.Categories.ToList();
        }

        public static Dictionary<int, string> GetCategoriesIdAndName()
        {
            return context.Categories.ToDictionary(c => c.CategoryId, c => c.CategoryName);
        }
    }

    public static class IncomeRepository
    {
        private static FPDbContext context = new FPDbContext();
        public static void AddIncomeForUser(int userId, decimal incomeSum)
        {
            var newIncome = new Income { UserId = userId, IncomeSum = incomeSum };
            
            context.Incomes.Add(newIncome);
            context.SaveChanges();
        }
    }

    public static class ExpenseRepository
    {
        private static FPDbContext context = new FPDbContext();
        public static void AddExpenseForUser(int userId, int categoryId, decimal expenseSum)
        {

            var newExpense = new Expense { UserId = userId, CategoryId = categoryId, ExpenseSum = expenseSum };

            context.Add(newExpense);
            context.SaveChanges();
        }
    }

    public static class CategorySumRepository
    {
        private static FPDbContext context = new FPDbContext();
        public static List<CategorySum> GetCategorySumsForUser(int userId)
        {
            return context.CategorySums.Where(cs => cs.UserId == userId).ToList();
        }
        public static CategorySum GetCategorySumForUser(int userId, int categoryId)
        {
            return context.CategorySums.FirstOrDefault(cs => cs.UserId == userId && cs.CategoryId == categoryId);
        }


    }

    public static class UserBudgetRepository
    {
        private static FPDbContext context = new FPDbContext();
        public static UserBudget GetUserBudget(int userId)
        {
            var userBudget = context.UserBudgets.FirstOrDefault(ub => ub.UserId == userId);
            return userBudget;
        }

    }
}
