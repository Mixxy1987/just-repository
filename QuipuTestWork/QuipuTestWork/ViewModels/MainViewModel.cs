using System;
using System.Windows.Input;
using Logic;
using QuipuTestWork.Commands;
using QuipuTestWork.Common;

namespace QuipuTestWork.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private LoadingViewModel _loadingViewModel;

        public event EventHandler ExitingHandler;

        public LoadingViewModel LoadingViewModel
        {
            get => _loadingViewModel;
            set => Set(nameof(LoadingViewModel), ref _loadingViewModel, value);
        }

        public ICommand CancelCommand { get; set; }

        public ICommand ExitCommand { get; set; }

        public MainViewModel(
            IDirectoryService directoryService,
            IDialogService dialogService,
            IWebLoader webLoader)
        {
            CancelCommand = new Command(CancelLoading);
            ExitCommand = new Command(Exit);
            LoadingViewModel = new LoadingViewModel(
                directoryService,
                dialogService,
                webLoader,
                ExitCommand,
                CancelCommand);
        }

        internal bool OnExiting()
        {
            return OnCancel();
        }

        private void CancelLoading(object parameter)
        {
            OnCancel();
        }

        private void Exit(object parameter)
        {
            ExitingHandler?.Invoke(this, new EventArgs());
        }

        private bool OnCancel()
        {
            if (LoadingViewModel.IsCancellationRequested)
            {
                return false;
            }
            LoadingViewModel.LoadCommand.Cancel();
            LoadingViewModel.IsCancellationRequested = true;
            return true;
        }
    }
}
