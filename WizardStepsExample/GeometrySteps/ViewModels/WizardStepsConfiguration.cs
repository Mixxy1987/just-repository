using GeometrySteps.Extensions;

namespace GeometrySteps.ViewModels
{
    /// <summary>
    /// Конфигурация шагов.
    /// </summary>
    public sealed class WizardStepsConfiguration
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="firstStepVm"><see cref="FirstStepViewModel"/>.</param>
        /// <param name="secondStepVm"><see cref="SecondStepViewModel"/>.</param>
        /// <param name="thirdStepVm"><see cref="ThirdStepViewModel"/>.</param>
        /// <param name="finalizationStep"><see cref="FinalizationStepViewModel"/>.</param>
        public WizardStepsConfiguration(
            FirstStepViewModel firstStepVm,
            SecondStepViewModel secondStepVm,
            ThirdStepViewModel thirdStepVm,
            FinalizationStepViewModel finalizationStep)
        {
            firstStepVm.AssertNotNull("firstStepVm");
            secondStepVm.AssertNotNull("secondStepVm");
            thirdStepVm.AssertNotNull("thirdStepVm");
            finalizationStep.AssertNotNull("finalizationStep");

            Init(firstStepVm, secondStepVm, thirdStepVm, finalizationStep);
        }

        /// <summary>
        /// Первый шаг мастера.
        /// </summary>
        public WizardStepViewModel FirstStep { get; private set; }

        /// <summary>
        /// Шаг ошибки.
        /// </summary>
        public ErrorViewModel ErrorStep { get; private set; }


        private void Init(
            FirstStepViewModel firstStepVm,
            SecondStepViewModel secondStepVm,
            ThirdStepViewModel thirdStepVm,
            FinalizationStepViewModel finalizationStep)
        {
            FirstStep = firstStepVm;

            FirstStep.Previous = FirstStep;
            FirstStep.Next = secondStepVm;

            secondStepVm.Next = thirdStepVm;
            secondStepVm.Previous = FirstStep;

            thirdStepVm.Next = finalizationStep;
            thirdStepVm.Previous = secondStepVm;

            finalizationStep.Next = finalizationStep;
            finalizationStep.Previous = thirdStepVm;

            ErrorStep = new ErrorViewModel { Previous = FirstStep };
        }
    }
}
