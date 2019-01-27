using System;

namespace GeometrySteps.Extensions
{
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
    }
}
