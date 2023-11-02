using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Models;

public partial class FPDbContext : DbContext
{
    public FPDbContext()
    {
    }

    public FPDbContext(DbContextOptions<FPDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CategorySum> CategorySums { get; set; }

    public virtual DbSet<Expense> Expenses { get; set; }

    public virtual DbSet<Income> Incomes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserBudget> UserBudgets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=FinancePillowDB;User Id=postgres;Password=postgres");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("category_pkey");

            entity.ToTable("category");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(255)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<CategorySum>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("category_sum");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.TotalExpense).HasColumnName("total_expense");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<Expense>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("expenses");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.ExpenseSum)
                .HasPrecision(10, 2)
                .HasColumnName("expense_sum");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Category).WithMany()
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("expenses_category_id_fkey");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("expenses_user_id_fkey");
        });

        modelBuilder.Entity<Income>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("incomes");

            entity.Property(e => e.IncomeSum)
                .HasPrecision(10, 2)
                .HasColumnName("income_sum");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("incomes_user_id_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "users_email_key").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");
        });

        modelBuilder.Entity<UserBudget>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("user_budget");

            entity.Property(e => e.Budget).HasColumnName("budget");
            entity.Property(e => e.TotalExpenses).HasColumnName("total_expenses");
            entity.Property(e => e.TotalIncomes).HasColumnName("total_incomes");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
