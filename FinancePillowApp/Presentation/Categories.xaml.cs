using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FinancePillow.WPF
{
    public partial class Categories
    {
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
    }
}
