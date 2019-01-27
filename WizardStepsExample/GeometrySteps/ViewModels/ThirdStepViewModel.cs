using GeometrySteps.Views;

namespace GeometrySteps.ViewModels
{
    /// <summary>
    /// Модель представления для <see cref="ThirdStep"/>.
    /// </summary>
    public class ThirdStepViewModel : WizardStepViewModel
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public ThirdStepViewModel()
        {
            Init();
        }

        private void Init()
        {
            IsCancelVisible = true;
            IsBackVisible = true;
            IsNextVisible = true;
        }
    }
}
