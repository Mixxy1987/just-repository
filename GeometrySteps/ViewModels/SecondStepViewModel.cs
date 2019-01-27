using GeometrySteps.Views;

namespace GeometrySteps.ViewModels
{
    /// <summary>
    ///     Модель представления для <see cref="SecondStep" />.
    /// </summary>
    public class SecondStepViewModel : WizardStepViewModel
    {

        /// <summary>
        /// Конструктор.
        /// </summary>
        public SecondStepViewModel()
        {
            Init();
        }

        /// <summary>
        /// Активация шага.
        /// </summary>
        public override void Activate()
        {
            //Init();
        }

        /// <summary>
        /// Выполнить действие шага перед переходом к следующему.
        /// </summary>
        public override void Proceed()
        {}

        private void Init()
        {
            IsCancelVisible = true;
            IsBackVisible = true;
            IsNextVisible = true;
        }
    }
}