using DAL;

namespace BLL
{
    public static class Logic
    {
        public static bool login(string email, string password)
        {
            return UserRepository.CheckUserCredentials(email, password);
        }
        public static int getUserId(string username) {
            return UserRepository.GetUserIdByEmail(username);
        }
        public static string getUserName(int userId)
        {
            return UserRepository.GetUsernameByUserId(userId);
        }
        public static bool register(string username, string password, string email)
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

        public static decimal getBudget(int userId)
        {
            var userBudget = UserBudgetRepository.GetUserBudget(userId);
            return userBudget != null ? userBudget.Budget : 0;
        }

        public static decimal getIncome(int userId)
        {
            var userBudget = UserBudgetRepository.GetUserBudget(userId);
            return userBudget != null ? userBudget.TotalIncomes : 0;
        }
        public static decimal getExpenses(int userId)
        {
            var userBudget = UserBudgetRepository.GetUserBudget(userId);
            return userBudget != null ? userBudget.TotalExpenses : 0;
        }
        public static decimal getCategorySum(int userId, int categoryId)
        {
            var categorySum = CategorySumRepository.GetCategorySumForUser(userId, categoryId);
            return categorySum != null ? categorySum.TotalExpense : 0;
        }

        public static void addIncome(int userId,  decimal income)
        {
            IncomeRepository.AddIncomeForUser(userId, income);
        }
        public static void addExpense(int userId, int categoryId, decimal expenseSum)
        {
            ExpenseRepository.AddExpenseForUser(userId, categoryId, expenseSum);
        }
    }
}