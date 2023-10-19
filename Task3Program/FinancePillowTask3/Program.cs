using System;
using System.Data;
using Npgsql;

namespace ConsoleApp
{
    class Program
    {
        static string connectionString = "Host=localhost;Username=postgres;Password=postgres;Database=FinancePillow";

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Show all tables");
                Console.WriteLine("2. Show users table");
                Console.WriteLine("3. Show expenses table");
                Console.WriteLine("4. Show incomes table");
                Console.WriteLine("5. Show category table");
                Console.WriteLine("6. Show sum_category table");
                Console.WriteLine("7. Generate and add 30 rows to tables users, incomes and expenses");
                Console.WriteLine("0. Exit");

                Console.Write("Enter your choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowAllTables();
                        break;
                    case "2":
                        ShowTable("users");
                        break;
                    case "3":
                        ShowTable("expenses");
                        break;
                    case "4":
                        ShowTable("incomes");
                        break;
                    case "5":
                        ShowTable("category");
                        break;
                    case "6":
                        ShowTable("sum_category");
                        break;
                    case "7":
                        GenerateAndAddRows();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }

        static void ShowAllTables()
        {
            ShowTable("users");
            ShowTable("expenses");
            ShowTable("incomes");
            ShowTable("category");
            ShowTable("sum_category");
        }

        static void ShowTable(string tableName)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = $"SELECT * FROM {tableName}";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, connection);
                DataTable dt = new DataTable();
                da.Fill(dt);

                Console.WriteLine($"\n{tableName} table:");
                foreach (DataRow row in dt.Rows)
                {
                    foreach (DataColumn col in dt.Columns)
                    {
                        Console.Write(row[col] + "\t");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }

        static void GenerateAndAddRows()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                // users
                for (int i = 31; i <= 30; i++)
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO users (user_id, username, email, user_password) VALUES (@user_id, @username, @email, @user_password)", connection))
                    {
                        cmd.Parameters.AddWithValue("user_id", i);
                        cmd.Parameters.AddWithValue("username", "user" + i);
                        cmd.Parameters.AddWithValue("email", "user" + i + "@gmail.com");
                        cmd.Parameters.AddWithValue("user_password", "password" + i);
                        cmd.ExecuteNonQuery();
                    }
                }

                // incomes
                for (int i = 1; i <= 30; i++)
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO incomes (income_sum, user_id) VALUES (@income_sum, @user_id)", connection))
                    {
                        cmd.Parameters.AddWithValue("income_sum", new Random().Next(1000));
                        cmd.Parameters.AddWithValue("user_id", new Random().Next(1, 60));
                        cmd.ExecuteNonQuery();
                    }
                }

                // expenses
                for (int i = 1; i <= 30; i++)
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO expenses (expenses_sum, user_id, category_id) VALUES (@expenses_sum, @user_id, @category_id)", connection))
                    {
                        cmd.Parameters.AddWithValue("expenses_sum", new Random().Next(1000));
                        cmd.Parameters.AddWithValue("user_id", new Random().Next(1, 31));
                        cmd.Parameters.AddWithValue("category_id", new Random().Next(1, 60));
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
