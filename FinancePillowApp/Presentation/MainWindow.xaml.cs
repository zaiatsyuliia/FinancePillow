using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media;

namespace FinancePillow.WPF
{
    public partial class MainWindow : Window
    {
        private double budget = 0;
        public MainWindow()
        {
            InitializeComponent();
            UpdateBudgetText();
        }

        private void UpdateBudgetText()
        {
            if (int.TryParse(incomeTextBlock.Text, out int currentIncome) &&
                int.TryParse(expenseTextBox.Text, out int currentExpense))
            {
                budget = currentIncome - currentExpense;
                budgetTextBlock.Text = budget.ToString();
            }
        }

        private void ChangeIncome_Click(object sender, RoutedEventArgs e)
        {
            overlayIncome.Visibility = Visibility.Visible;
        }

        private void ChangeExpense_Click(object sender, RoutedEventArgs e)
        {
            overlayExpense.Visibility = Visibility.Visible;
        }


        private void AddAmount_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(amountTextBoxForIncomes.Text, out int amountToAdd))
            {
                if (int.TryParse(incomeTextBlock.Text, out int currentAmount))
                {
                    currentAmount += amountToAdd;
                    incomeTextBlock.Text = currentAmount.ToString(); // Оновлення суми доходів
                }
                if (double.TryParse(budgetTextBlock.Text, out double currentBudget))
                {
                    currentBudget += amountToAdd;
                    budgetTextBlock.Text = currentBudget.ToString(); // Оновлення бюджету
                }
            }
            overlayIncome.Visibility = Visibility.Collapsed;
        }

        private void AddExpense_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(amountTextBoxForExpences.Text, out int amountToRemove))
            {
                if (int.TryParse(expenseTextBox.Text, out int currentAmount))
                {
                    currentAmount += amountToRemove;
                    expenseTextBox.Text = currentAmount.ToString();
                }
                if (double.TryParse(budgetTextBlock.Text, out double currentBudget))
                {
                    currentBudget -= amountToRemove;
                    budgetTextBlock.Text = currentBudget.ToString(); // Оновлення бюджету
                }
            }

            overlayExpense.Visibility = Visibility.Collapsed;

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
    }
}
