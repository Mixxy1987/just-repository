using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extensions
{
    /// <summary>
    ///     Расширения над объектами ссылочных типов.
    /// </summary>
    public static class ClassExtensions
    {
        /// <summary>
        /// Бросить исключение <exception cref="NullReferenceException"> если <paramref name="value"/> - null.</exception>
        /// </summary>
        /// <param name="value">Проверяемое зачение.</param>
        /// <param name="argumentName">Имя проверяемого аргумента.</param>
        /// <typeparam name="T">Тип проверяемого объекта.</typeparam>
        /// <exception cref="ArgumentNullException">Бросается, если <paramref name="value"/> - null.</exception>
        public static void AssertNotNull<T>(this T value, string argumentName) where T : class
        {
            if (value == null)
            {
                var exception = new ArgumentNullException(argumentName);
                throw exception;
            }
        }

        /// <summary>
        /// Преобразовать <paramref name="source"/> к типу <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">Тип, к которому необходимо преобразовать <paramref name="source"/>.</typeparam>
        /// <param name="source">Значение, которое необходимо преобразовать к типу <typeparamref name="T"/>.</param>
        /// <returns>Объект типа T или null.</returns>
        public static T Cast<T>(this object source) where T : class
        {
            return source as T;
        }
    }
}
