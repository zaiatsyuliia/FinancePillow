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
using System.Windows.Shapes;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;


namespace FinancePillowApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FirstButton_Click(object sender, RoutedEventArgs e)
        {
            overlayGrid.Visibility = Visibility.Visible;
        }

        private void AddAmount_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(amountTextBox.Text, out int amountToAdd))
            {
                if (int.TryParse(incomeTextBlock.Text, out int currentAmount))
                {
                    currentAmount += amountToAdd;
                    incomeTextBlock.Text = currentAmount.ToString();
                }
            }

            overlayGrid.Visibility = Visibility.Collapsed;
            Incomes.Opacity = 1.0;
            Expences.Opacity = 1.0;
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

    }
}
