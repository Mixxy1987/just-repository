using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using Common;
using Logic;
using QuipuTestWork.Commands;
using QuipuTestWork.Common;
using QuipuTestWork.Models;

namespace QuipuTestWork.ViewModels
{
    public class LoadingViewModel : BaseViewModel
    {
        private readonly Progress<SetupStateProgress> _progress;
        private ICommand _cancelCommand;
        private ICommand _exitCommand;
        private SetupStateProgressViewModel _current;
        private bool _isCancellationRequested;
        private bool _canStart;
        private bool _canCancel;
        private bool _canChooseFolder = true;

        private readonly IDirectoryService _directoryService;
        private readonly IDialogService _dialogService;
        private readonly IWebLoader _webLoader;
        private string _pathToFile;
        private ObservableCollection<LinkResult> _linksResults;

        public ICommand CancelCommand
        {
            get => _cancelCommand;
            set => Set(nameof(CancelCommand), ref _cancelCommand, value);
        }

        public ICommand ExitCommand
        {
            get => _exitCommand;
            set => Set(nameof(ExitCommand), ref _exitCommand, value);
        }

        public SetupStateProgressViewModel Current
        {
            get => _current;
            set => Set(nameof(Current), ref _current, value);
        }

        public bool IsCancellationRequested
        {
            get => _isCancellationRequested;
            set
            {
                Set(nameof(IsCancellationRequested), ref _isCancellationRequested, value);
                CanCancel = false;
            }
        }

        public string PathToFile
        {
            get => _pathToFile; 
            set
            {
                if (_pathToFile == value)
                {
                    return;
                }
                Set(nameof(PathToFile), ref _pathToFile, value);
                ValidatePath(PathToFile);
            }
        }

        public ICommand SelectFolderCommand { get; set; }

        public bool CanStart
        {
            get => _canStart;
            set => Set(nameof(CanStart), ref _canStart, value);
        }

        public bool CanCancel
        {
            get => _canCancel;
            set => Set(nameof(CanCancel), ref _canCancel, value);
        }

        public bool CanChooseFolder
        {
            get => _canChooseFolder;
            set => Set(nameof(CanChooseFolder), ref _canChooseFolder, value);
        }

        public IAsyncCommand LoadCommand { get; set; }

        public IWebLoader WebLoader { get; set; }

        public ObservableCollection<LinkResult> LinksResults
        {
            get => _linksResults;
            set
            {
                if (_linksResults == value)
                {
                    return;
                }
                Set(nameof(LinksResults), ref _linksResults, value);
            }
        }

        public LoadingViewModel(
            IDirectoryService directoryService,
            IDialogService dialogService,
            IWebLoader webLoader,
            ICommand exitCommand,
            ICommand cancelCommand)
        {
            _directoryService = directoryService;
            _dialogService = dialogService;
            _webLoader = webLoader;
            _cancelCommand = cancelCommand;
            _exitCommand = exitCommand;
            _progress = new Progress<SetupStateProgress>();
            _progress.ProgressChanged += HandleProgressChanged;
            Current = new SetupStateProgressViewModel("");
            SelectFolderCommand = new Command(x => SelectFolder());
            LoadCommand = new AsyncCommand(StartLoading);
        }

        /// <summary>
        /// Запуск процесса загрузки url
        /// </summary>
        public async Task StartLoading(object parameter, CancellationToken token)
        {
            WebLoader = _webLoader;
            LinksResults = new ObservableCollection<LinkResult>();
            IUiContext context = new UiContext(Dispatcher.CurrentDispatcher);
            IList<string> fileContent = _directoryService.ReadFileContent(_pathToFile).ToList();
            CanCancel = true;
            CanStart = false;
            CanChooseFolder = false;
            await Task.Run(() => WebLoader.Load(fileContent, context, LinksResults, token, _progress), token);
            CanStart = true;
            CanChooseFolder = true;
            IsCancellationRequested = false;
        }

        /// <summary>
        /// Выбор пути.
        /// </summary>
        private void SelectFolder()
        {
            PathToFile = _dialogService.OpenFileDialog(
                _directoryService.GetSpecialDirectory(Environment.SpecialFolder.MyDocuments));
        }

        /// <summary>
        /// Проверка валидности пути.
        /// </summary>
        /// <param name="path">Путь.</param>
        private void ValidatePath(string path)
        {
            if (!_directoryService.ValidatePath(path))
            {
                CanStart = false;
                CanCancel = false;
                throw new NotSupportedException();
            }
            CanStart = true;
            CanCancel = false;
        }

        /// <summary>
        /// Отображение прогресса.
        /// </summary>
        private void HandleProgressChanged(object sender, SetupStateProgress e)
        {
            if (e.Percent < 0)
            {
                return;
            }
            Current.SetupStateProgress = e;
        }
    }
}
