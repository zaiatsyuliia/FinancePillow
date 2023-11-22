using DAL;

namespace BLL
{
    public static class Logic
    {
        public static bool Login(string email, string password)
        {
            return UserRepository.CheckUserCredentials(email, password);
        }
        public static int GetUserId(string username) {
            return UserRepository.GetUserIdByEmail(username);
        }
        public static string GetUserName(int userId)
        {
            return UserRepository.GetUsernameByUserId(userId);
        }
        public static bool Register(string username, string password, string email)
        {
            if (UserRepository.CheckUserExists(email))
            {
                return false;
            }
            else
            {
                UserRepository.AddUser(username, email, password);
                while (!UserRepository.CheckUserExists(email))
                {
                    System.Threading.Thread.Sleep(100);
                }
                
                return true;
            }
        }

        public static decimal GetBudget(int userId)
        {
            var userBudget = UserBudgetRepository.GetUserBudget(userId);
            return userBudget != null ? userBudget.Budget : 0;
        }

        public static decimal GetIncome(int userId)
        {
            var userBudget = UserBudgetRepository.GetUserBudget(userId);
            return userBudget != null ? userBudget.TotalIncomes : 0;
        }
        public static decimal GetExpenses(int userId)
        {
            var userBudget = UserBudgetRepository.GetUserBudget(userId);
            return userBudget != null ? userBudget.TotalExpenses : 0;
        }
        public static decimal GetCategorySum(int userId, int categoryId)
        {
            var categorySum = CategorySumRepository.GetCategorySumForUser(userId, categoryId);
            return categorySum != null ? categorySum.TotalExpense : 0;
        }

        public static void AddIncome(int userId,  decimal income)
        {
            IncomeRepository.AddIncomeForUser(userId, income);
        }
        public static void AddExpense(int userId, int categoryId, decimal expenseSum)
        {
            ExpenseRepository.AddExpenseForUser(userId, categoryId, expenseSum);
        }
    }
}