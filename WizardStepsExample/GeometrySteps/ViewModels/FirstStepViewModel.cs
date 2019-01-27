using GeometrySteps.Views;

namespace GeometrySteps.ViewModels
{
    /// <summary>
    /// Модель представления для <see cref="FirstStep"/>.
    /// </summary>
    public class FirstStepViewModel : WizardStepViewModel
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public FirstStepViewModel()
        {
            Init();
        }

        private void Init()
        {
            IsCancelVisible = true;
            IsBackVisible = false;
            IsNextVisible = true;
        }
    }
}
