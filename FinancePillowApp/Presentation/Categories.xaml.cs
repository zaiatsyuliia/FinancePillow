using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Presentation
{
    public partial class Categories : Window
    {
        public Categories()
        {
            InitializeComponent();
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
    }
}
