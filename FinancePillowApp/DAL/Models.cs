using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinancePillow.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$", ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class Income
    {
        public decimal IncomeSum { get; set; }
        public int UserId { get; set; }
    }

    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }

    public class Expense
    {
        public decimal ExpenseSum { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
    }

    public class CategorySum
    {
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public decimal TotalExpense { get; set; }
    }
}
