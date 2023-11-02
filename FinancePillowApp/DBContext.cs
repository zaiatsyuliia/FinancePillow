using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class FPDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Server=localhost;Port=5432;Database=FinancePillowDB;User Id=postgres;Password=postgres;";
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<CategorySum> CategorySums { get; set; }
        public DbSet<UserBudget> UserBudgets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
