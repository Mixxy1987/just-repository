using  GeometrySteps.Views;

namespace GeometrySteps.ViewModels
{
    /// <summary>
    /// Модель представления для <see cref="FinalizationStepSuccess"/>
    /// </summary>
    public class FinalizationStepViewModel : WizardStepViewModel
    {

        /// <summary>
        /// Конструктор.
        /// </summary>
        public FinalizationStepViewModel()
        {
            Init();
        }

        /// <summary>
        /// Активация шага.
        /// </summary>
        public override void Activate()
        {
            Init();
        }

        /// <summary>
        /// Выполнить действие шага перед переходом к следующему.
        /// </summary>
        public override void Proceed()
        {
        }

        private void Init()
        {
            IsCloseVisible = true;
            IsCancelVisible = false;
            IsBackVisible = false;
            IsNextVisible = false;
        }
    }
}
