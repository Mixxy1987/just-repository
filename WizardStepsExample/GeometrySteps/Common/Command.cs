using System;
using System.Windows.Input;

namespace GeometrySteps.Common
{
    /// <summary>
    ///   Реализация команды через делегаты.
    /// </summary>
    public class Command : ICommand
    {
        /// <summary>
        ///   Доступность команды.
        /// </summary>
        private readonly Predicate<object> canExecute;

        /// <summary>
        ///   Действие.
        /// </summary>
        private readonly Action<object> execute;

        /// <summary>
        ///   Создает новую команду.
        /// </summary>
        /// <param name="execute"> Действие. </param>
        public Command(Action<object> execute)
            : this(null, execute)
        {
        }

        /// <summary>
        ///   Создает новую команду.
        /// </summary>
        /// <param name="canExecute"> Доступность команды. </param>
        /// <param name="execute"> Действие. </param>
        public Command(Predicate<object> canExecute, Action<object> execute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }
            this.canExecute = canExecute;
            this.execute = execute;
        }

        /// <summary>
        ///   Событие изменения доступности команды.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested += value; }
        }

        /// <summary>
        ///   Проверка доступности команды.
        /// </summary>
        /// <param name="parameter"> Параметр операции. </param>
        /// <returns> Доступность команды. </returns>
        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        /// <summary>
        ///   Выполнение команды.
        /// </summary>
        /// <param name="parameter"> Параметр операции. </param>
        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
