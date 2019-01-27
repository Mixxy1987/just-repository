using System.Windows;
using GeometrySteps.ViewModels;

namespace GeometrySteps
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(NavigationViewModel dataContext)
        {
            InitializeComponent();
            DataContext = dataContext;
        }
    }
}
