using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;

namespace BLL.Tests
{
    [TestClass]
    public class LogicTests
    {
        private Mock<FPDbContext> contextMock;
        private Mock<DbSet<User>> usersMock;
        private Mock<DbSet<Category>> categoriesMock;
        private Mock<DbSet<Income>> incomesMock;
        private Mock<DbSet<Expense>> expensesMock;
        private Mock<DbSet<CategorySum>> categorySumsMock;
        private Mock<DbSet<UserBudget>> userBudgetsMock;

        [TestInitialize]
        public void Initialize()
        {
            contextMock = new Mock<FPDbContext>();
            usersMock = new Mock<DbSet<User>>();
            categoriesMock = new Mock<DbSet<Category>>();
            incomesMock = new Mock<DbSet<Income>>();
            expensesMock = new Mock<DbSet<Expense>>();
            categorySumsMock = new Mock<DbSet<CategorySum>>();
            userBudgetsMock = new Mock<DbSet<UserBudget>>();

            contextMock.Setup(c => c.Users).Returns(usersMock.Object);
            contextMock.Setup(c => c.Categories).Returns(categoriesMock.Object);
            contextMock.Setup(c => c.Incomes).Returns(incomesMock.Object);
            contextMock.Setup(c => c.Expenses).Returns(expensesMock.Object);
            contextMock.Setup(c => c.CategorySums).Returns(categorySumsMock.Object);
            contextMock.Setup(c => c.UserBudgets).Returns(userBudgetsMock.Object);
        }

        [TestMethod]
        public void TestLogin_ValidCredentials_ReturnsTrue()
        {
            string email = "test@example.com";
            string password = "password";

            usersMock.Setup(u => u.Any(It.IsAny<Func<User, bool>>())).Returns(true);

            bool result = Logic.Login(email, password);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestLogin_InvalidCredentials_ReturnsFalse()
        {
            string email = "test@example.com";
            string password = "password";

            usersMock.Setup(u => u.Any(It.IsAny<Func<User, bool>>())).Returns(false);

            bool result = Logic.Login(email, password);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestGetUserId_ValidUsername_ReturnsUserId()
        {
            string email = "test@example.com";
            int expectedUserId = 1;

            usersMock.Setup(u => u.FirstOrDefault(It.IsAny<Func<User, bool>>())).Returns(new User { UserId = expectedUserId });

            int result = Logic.GetUserId(email);

            Assert.AreEqual(expectedUserId, result);
        }

        [TestMethod]
        public void TestGetUserName_ValidUserId_ReturnsUsername()
        {
            int userId = 1;
            string expectedUsername = "testuser";

            usersMock.Setup(u => u.FirstOrDefault(It.IsAny<Func<User, bool>>())).Returns(new User { Username = expectedUsername });

            string result = Logic.GetUserName(userId);

            Assert.AreEqual(expectedUsername, result);
        }

        [TestMethod]
        public void TestRegister_NewUser_ReturnsTrue()
        {
            string username = "newuser";
            string email = "newuser@example.com";
            string password = "newpassword";

            usersMock.Setup(u => u.Any(It.IsAny<Func<User, bool>>())).Returns(false);

            bool result = Logic.Register(username, password, email);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestRegister_ExistingUser_ReturnsFalse()
        {
            string username = "existinguser";
            string email = "existinguser@example.com";
            string password = "existingpassword";

            usersMock.Setup(u => u.Any(It.IsAny<Func<User, bool>>())).Returns(true);

            bool result = Logic.Register(username, password, email);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestGetBudget_ValidUserId_ReturnsUserBudget()
        {
            int userId = 1;
            decimal expectedBudget = 1000;

            userBudgetsMock.Setup(ub => ub.FirstOrDefault(It.IsAny<Func<UserBudget, bool>>())).Returns(new UserBudget { Budget = expectedBudget });

            decimal result = Logic.GetBudget(userId);

            Assert.AreEqual(expectedBudget, result);
        }

        [TestMethod]
        public void TestGetIncome_ValidUserId_ReturnsUserIncome()
        {
            int userId = 1;
            decimal expectedIncome = 500;

            userBudgetsMock.Setup(ub => ub.FirstOrDefault(It.IsAny<Func<UserBudget, bool>>())).Returns(new UserBudget { TotalIncomes = expectedIncome });

            decimal result = Logic.GetIncome(userId);

            Assert.AreEqual(expectedIncome, result);
        }

        [TestMethod]
        public void TestGetExpenses_ValidUserId_ReturnsUserExpenses()
        {
            int userId = 1;
            decimal expectedExpenses = 300;

            userBudgetsMock.Setup(ub => ub.FirstOrDefault(It.IsAny<Func<UserBudget, bool>>())).Returns(new UserBudget { TotalExpenses = expectedExpenses });

            decimal result = Logic.GetExpenses(userId);

            Assert.AreEqual(expectedExpenses, result);
        }

        [TestMethod]
        public void TestGetCategorySum_ValidUserIdAndCategoryId_ReturnsCategorySum()
        {
            int userId = 1;
            int categoryId = 2;
            decimal expectedCategorySum = 50;

            categorySumsMock.Setup(cs => cs.FirstOrDefault(It.IsAny<Func<CategorySum, bool>>())).Returns(new CategorySum { TotalExpense = expectedCategorySum });

            decimal result = Logic.GetCategorySum(userId, categoryId);

            Assert.AreEqual(expectedCategorySum, result);
        }

        [TestMethod]
        public void TestAddIncome_ValidUserIdAndIncome_AddsIncome()
        {
            int userId = 1;
            decimal income = 200;

            Logic.AddIncome(userId, income);

            incomesMock.Verify(i => i.Add(It.IsAny<Income>()), Times.Once);
            contextMock.Verify(c => c.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void TestAddExpense_ValidUserIdAndCategoryIdAndExpense_AddsExpense()
        {
            int userId = 1;
            int categoryId = 3;
            decimal expenseSum = 75;

            Logic.AddExpense(userId, categoryId, expenseSum);

            expensesMock.Verify(e => e.Add(It.IsAny<Expense>()), Times.Once);
            contextMock.Verify(c => c.SaveChanges(), Times.Once);
        }
    }
}
