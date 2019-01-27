using GeometrySteps.Common;

namespace GeometrySteps.ViewModels
{
    /// <summary>
    /// Базовая модель представления для шаг мастера.
    /// </summary>
    public class WizardStepViewModel : ViewModelBase
    {
        private bool isBackVisible;

        private bool isCancelVisible;
        private bool isCloseVisible;

        private bool isNextVisible;

        private bool isReadyVisible;

        /// <summary>
        /// Видима ли кнопка "Назад".
        /// </summary>
        public bool IsBackVisible
        {
            get { return isBackVisible; }
            set
            {
                if (isBackVisible == value)
                {
                    return;
                }

                isBackVisible = value;
                Notify(() => IsBackVisible);
            }
        }

        /// <summary>
        /// Видима ли кнопка "Отмена".
        /// </summary>
        public bool IsCancelVisible
        {
            get { return isCancelVisible; }
            set
            {
                if (isCancelVisible == value)
                {
                    return;
                }

                isCancelVisible = value;
                Notify(() => IsCancelVisible);
            }
        }

        /// <summary>
        /// Видима ли кнопка "Закрыть".
        /// </summary>
        public bool IsCloseVisible
        {
            get { return isCloseVisible; }
            set
            {
                if (isCloseVisible == value)
                {
                    return;
                }

                isCloseVisible = value;
                Notify(() => IsCloseVisible);
            }
        }

        /// <summary>
        /// Видима ли кнопка "Далее".
        /// </summary>
        public bool IsNextVisible
        {
            get { return isNextVisible; }
            set
            {
                if (isNextVisible == value)
                {
                    return;
                }

                isNextVisible = value;
                Notify(() => IsNextVisible);
            }
        }

        /// <summary>
        /// Видима ли кнопка "Готово"
        /// </summary>
        public bool IsReadyVisible
        {
            get { return isReadyVisible; }
            set
            {
                if (isReadyVisible == value)
                {
                    return;
                }

                isReadyVisible = value;
                Notify(() => IsReadyVisible);
            }
        }

        /// <summary>
        /// Следующий шаг.
        /// </summary>
        public WizardStepViewModel Next { get; set; }

        /// <summary>
        /// Предыдущий шаг.
        /// </summary>
        public WizardStepViewModel Previous { get; set; }

        /// <summary>
        /// Активация шага.
        /// </summary>
        public virtual void Activate()
        {
        }

        /// <summary>
        /// Выполнить действие шага перед переходом к следующему.
        /// </summary>
        public virtual void Proceed()
        {
        }

        /// <summary>
        /// Выполнить валидацию.
        /// </summary>
        /// <returns>True, если валидация прошла, иначе false.</returns>
        public virtual bool Validate()
        {
            return true;
        }
    }
}
