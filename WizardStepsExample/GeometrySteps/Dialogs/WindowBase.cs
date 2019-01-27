using System;
using System.Windows;

namespace GeometrySteps.Dialogs
{
    /// <summary>
    /// Базовый класс для окон.
    /// </summary>
    public class WindowBase : Window
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public WindowBase()
        {
            IsVisibleChanged += VisibleChanged;

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void VisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility != Visibility.Visible)
            {
                return;
            }

            EnsureWindowDiplaysOnTop();
        }

        private void EnsureWindowDiplaysOnTop()
        {
            Activate();
            Topmost = true;
            Topmost = false;
            Focus();
        }
    }
}
