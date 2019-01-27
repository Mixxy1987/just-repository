namespace GeometrySteps.ViewModels
{
    /// <summary>
    /// Модель представления ошибки.
    /// </summary>
    public class ErrorViewModel : WizardStepViewModel
    {
        private string errorMessage;

        /// <summary>
        /// Конструктор.
        /// </summary>
        public ErrorViewModel()
        {
            Init();
        }

        /// <summary>
        /// Сообщение об ошибке.
        /// </summary>
        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                if (errorMessage == value)
                {
                    return;
                }

                errorMessage = value;
                Notify(() => ErrorMessage);
            }
        }

        /// <summary>
        /// Активация шага.
        /// </summary>
        public override void Activate()
        {
            Init();
        }

        private void Init()
        {
            IsCloseVisible = true;
        }
    }
}
