using System.Windows;
using System.Windows.Controls;
using GeometrySteps.Extensions;
using GeometrySteps.ViewModels;

namespace GeometrySteps.TemplateSelectors
{
    /// <summary>
    /// Выбирает DataTemplate для шага мастера в зависимости от типа DataContext.
    /// </summary>
    public class WizardStepTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Шаблон первой страницы.
        /// </summary>
        public DataTemplate FirstStepTemplate { get; set; }

        /// <summary>
        /// Шаблон второй страницы.
        /// </summary>
        public DataTemplate SecondStepTemplate { get; set; }

        /// <summary>
        /// Шаблон третьей страницы.
        /// </summary>
        public DataTemplate ThirdStepTemplate { get; set; }

        /// <summary>
        /// Шаблон ошибки.
        /// </summary>
        public DataTemplate FailureTemplate { get; set; }

        /// <summary>
        /// Шаблон успеха.
        /// </summary>
        public DataTemplate SuccessTemplate { get; set; }

        /// <summary>
        /// When overridden in a derived class, returns a <see cref="T:System.Windows.DataTemplate"/> based on custom logic.
        /// </summary>
        /// <returns>
        /// Returns a <see cref="T:System.Windows.DataTemplate"/> or null. The default value is null.
        /// </returns>
        /// <param name="item">The data object for which to select the template.</param><param name="container">The data-bound object.</param>
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            DataTemplate result = null;

            item.ToOption()
                .MatchType<FirstStepViewModel>(x => result = FirstStepTemplate)
                .MatchType<SecondStepViewModel>(x => result = SecondStepTemplate)
                .MatchType<ThirdStepViewModel>(x => result = ThirdStepTemplate)
                .MatchType<FinalizationStepViewModel>(x => result = SuccessTemplate)
                .MatchType<ErrorViewModel>(x => result = FailureTemplate);

            return result;
        }
    }
}
