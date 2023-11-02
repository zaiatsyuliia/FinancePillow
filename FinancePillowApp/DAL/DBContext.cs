using FinancePillow.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FinancePillow.DAL
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.UserId);
            modelBuilder.Entity<Income>().HasKey(i => i.IncomeSum);
            modelBuilder.Entity<Category>().HasKey(c => c.CategoryId);
            modelBuilder.Entity<Expense>().HasKey(e => new { e.UserId, e.CategoryId });
            modelBuilder.Entity<CategorySum>().HasKey(cs => new { cs.UserId, cs.CategoryId });
            modelBuilder.Entity<UserBudget>().HasKey(ub => ub.UserId);
        }
    }
}
