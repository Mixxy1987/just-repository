using Common;

namespace QuipuTestWork.ViewModels
{
    /// <summary>
    /// Модель представления для отображения прогресса
    /// </summary>
    public class SetupStateProgressViewModel : BaseViewModel
    {
        private SetupStateProgress _setupStateProgress;

        public SetupStateProgress SetupStateProgress
        {
            get => _setupStateProgress;
            set => Set(nameof(SetupStateProgress), ref _setupStateProgress, value);
        }

        public SetupStateProgressViewModel(string message)
        {
            SetupStateProgress = new SetupStateProgress(message);
        }
    }
}
