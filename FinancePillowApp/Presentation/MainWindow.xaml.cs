using DAL.Models;
using Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BLL;

namespace Presentation
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            updateBudget();
            menuUsername.Content = Logic.getUserName(UserData.userId);
        }

        private void ChangeIncome_Click(object sender, RoutedEventArgs e)
        {
            overlayIncome.Visibility = Visibility.Visible;
        }

        private void ChangeExpense_Click(object sender, RoutedEventArgs e)
        {
            overlayExpense.Visibility = Visibility.Visible;
        }


        private void AddIncome_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(amountTextBoxForIncomes.Text, out decimal income))
            {
                Logic.addIncome(UserData.userId, income);
                updateBudget();
                overlayExpense.Visibility = Visibility.Collapsed;
            }
            else
            {
                MessageBox.Show($"Can't parse /'{amountTextBoxForIncomes.Text}/' to decimal number. Please try again", "Invalid expense data", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            overlayIncome.Visibility = Visibility.Collapsed;
        }

        private void AddExpense_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(amountTextBoxForExpences.Text, out decimal expense))
            {
                int x = categoryComboBox.SelectedIndex;
                Logic.addExpense(UserData.userId, categoryComboBox.SelectedIndex + 1, expense);
                updateBudget();
                overlayExpense.Visibility = Visibility.Collapsed;
            }
            else
            {
                MessageBox.Show($"Can't parse /'{amountTextBoxForExpences.Text}/' to decimal number. Please try again", "Invalid expense data", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool isMenuVisible = false;

        private void ToggleMenuVisibility(object sender, MouseButtonEventArgs e)
        {
            if (isMenuVisible)
            {
                menuCanvas.Visibility = Visibility.Collapsed;
            }
            else
            {
                menuCanvas.Visibility = Visibility.Visible;
            }

            isMenuVisible = !isMenuVisible;
        }

        private void CloseMenu(object sender, RoutedEventArgs e)
        {
            menuCanvas.Visibility = Visibility.Collapsed;
        }

        private void Window_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (menuCanvas.IsVisible && !IsMouseOverElement(menuCanvas, e))
            {
                menuCanvas.Visibility = Visibility.Collapsed;
            }
        }

        private bool IsMouseOverElement(FrameworkElement element, MouseEventArgs e)
        {
            if (element == null) return false;
            Point mousePos = e.GetPosition(element);
            return new Rect(0, 0, element.ActualWidth, element.ActualHeight).Contains(mousePos);
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Enter sum")
            {
                textBox.Text = "";
                textBox.Foreground = Brushes.Black;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Enter sum";
                textBox.Foreground = Brushes.Gray;
            }
        }

        private void CategoriesButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Categories categoriesWindow = new Categories();
            categoriesWindow.Show();
        }
        private void MainButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();
        }
        private void ReturnToLogin_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LoginWindow LoginWindow = new LoginWindow();
            LoginWindow.Show();
        }

        private void updateBudget()
        {
            incomeTextBlock.Text = ((int)Logic.getIncome(UserData.userId)).ToString();
            expenseTextBlock.Text = ((int)Logic.getExpenses(UserData.userId)).ToString();
            budgetTextBlock.Text = ((int)Logic.getBudget(UserData.userId)).ToString();
        }
    }
}
