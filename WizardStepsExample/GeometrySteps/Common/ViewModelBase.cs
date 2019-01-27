using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace GeometrySteps.Common
{
    /// <summary>
    ///     Базовый класс ViewModel-ей.
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged, IDataErrorInfo
    {
        /// <summary>
        ///     Событие изменения свойств объекта.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets an error message indicating what is wrong with this object.
        /// </summary>
        /// <returns>
        /// An error message indicating what is wrong with this object. The default is an empty string ("").
        /// </returns>
        public virtual string Error
        {
            get { return null; }
        }

        /// <summary>
        /// Валидация значения свойства с именем <paramref name="propertyName"/>.
        /// </summary>
        /// <param name="propertyName">Имя свойства.</param>
        /// <returns>Строку ошибки.</returns>
        public virtual string this[string propertyName]
        {
            get { return null; }
        }

        /// <summary>
        ///     Оповещает об изменении свойства объекта.
        /// </summary>
        /// <typeparam name="T"> Тип объекта. </typeparam>
        /// <param name="action"> Название свойства. </param>
        protected void Notify<T>(Expression<Func<T>> action)
        {
            string propertyName = GetPropertyName(action);
            Notify(propertyName);
        }

        /// <summary>
        ///     Оповещает об изменении свойства объекта.
        /// </summary>
        /// <param name="propertyName">Имя свойства.</param>
        protected void Notify(string propertyName)
        {
            if (PropertyChanged == null)
            {
                return;
            }
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private static string GetPropertyName<T>(Expression<Func<T>> action)
        {
            var expression = (MemberExpression)action.Body;
            return expression.Member.Name;
        }
    }
}
