using System;
using System.Windows;
using GeometrySteps.Common;
using GeometrySteps.Extensions;
using GeometrySteps.Properties;

namespace GeometrySteps.ViewModels
{
    /// <summary>
    ///     Модель представления навигации.
    /// </summary>
    public class NavigationViewModel : ViewModelBase
    {
        private WizardStepViewModel currentStepContext;
        private ErrorViewModel errorViewModel;

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="stepsConfiguration"><see cref="WizardStepViewModel"/>.</param>
        public NavigationViewModel(WizardStepsConfiguration stepsConfiguration)
        {
            stepsConfiguration.AssertNotNull("stepsConfiguration");

            InitSteps(stepsConfiguration);
            InitCommands();
        }

        /// <summary>
        ///     Команда отмены.
        /// </summary>
        public Command CancelCommand { get; set; }

        /// <summary>
        /// Команда закрытия приложения.
        /// </summary>
        public Command CloseCommand { get; set; }

        /// <summary>
        ///     Модель представления текущего шага.
        /// </summary>
        public WizardStepViewModel CurrentStepContext
        {
            get { return currentStepContext; }
            set
            {
                if (currentStepContext == value)
                {
                    return;
                }

                currentStepContext = value;
                Notify(() => CurrentStepContext);
            }
        }

         /// <summary>
         /// <see cref="ErrorViewModel"/>.
         /// </summary>
         public ErrorViewModel ErrorViewModel
         {
             get { return errorViewModel; }
             set
             {
                 if (errorViewModel == value)
                 {
                     return;
                 }

                 errorViewModel = value;
                 Notify(() => ErrorViewModel);
             }
         }

         /// <summary>
         ///     Команда завершения.
         /// </summary>
         public Command FinishCommand { get; set; }

         /// <summary>
         ///     Команда перехода к предыдущему шагу.
         /// </summary>
         public Command MoveBackCommand { get; set; }

         /// <summary>
         ///     Команда перехода к следующему шагу.
         /// </summary>
         public Command MoveNextCommand { get; set; }


         private static void Shutdown()
         {
             Application.Current.Shutdown(0);
         }

         private void Cancel()
         {
             FinishWithError(Resources.Error_OperationCancelled);
         }

         private void Finish()
         {
             try
             {
                 CurrentStepContext.ToOption()
                     .MatchType<FinalizationStepViewModel>(x => CurrentStepContext.Proceed());

                 Shutdown();
             }
             catch (Exception ex)
             {
                 FinishWithError(ex.Message);
             }
         }

         private void FinishWithError(string errorMessage)
         {
             CurrentStepContext = ErrorViewModel;
             ErrorViewModel.ErrorMessage = errorMessage;
             CurrentStepContext.Activate();
         }

         private void InitCommands()
         {
             MoveNextCommand = new Command(x =>
             {
                 if (CurrentStepContext.Validate())
                 {
                     try
                     {
                         CurrentStepContext.Proceed();
                         CurrentStepContext = CurrentStepContext.Next;
                         CurrentStepContext.Activate();
                     }
                     catch (Exception ex)
                     {
                         //logger.Error(ex);
                         ErrorViewModel.ErrorMessage = ex.Message;
                         CurrentStepContext = ErrorViewModel;
                         ErrorViewModel.Activate();
                     }
                 }
             });

             MoveBackCommand = new Command(x => CurrentStepContext = CurrentStepContext.Previous);
             FinishCommand = new Command(x => Finish());
             CancelCommand = new Command(x => Cancel());
             CloseCommand = new Command(x => Shutdown());

         }

         private void InitSteps(WizardStepsConfiguration stepsConfiguration)
         {
             ErrorViewModel = stepsConfiguration.ErrorStep;
             CurrentStepContext = stepsConfiguration.FirstStep;
             CurrentStepContext.Activate();
         }
    }
}
