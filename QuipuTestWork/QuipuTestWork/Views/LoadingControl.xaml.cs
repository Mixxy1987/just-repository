using System.Windows;
using System.Windows.Controls;
using QuipuTestWork.ViewModels;

namespace QuipuTestWork.Views
{
    /// <summary>
    /// Interaction logic for LoadingControl.xaml
    /// </summary>
    public partial class LoadingControl : UserControl
    {
        public LoadingViewModel ViewModel
        {
            get => (LoadingViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(LoadingViewModel), typeof(LoadingControl),
                new FrameworkPropertyMetadata { BindsTwoWayByDefault = true });

        public LoadingControl()
        {
            InitializeComponent();
        }
    }
}
