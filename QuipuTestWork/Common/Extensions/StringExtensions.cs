using System;

namespace Common.Extensions
{
    /// <summary>
    /// Методы расширения для String.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Бросить исключение,если строка Null или пуста.
        /// </summary>
        /// <param name="source">Проверяемая строка.</param>
        /// <param name="argumentName">Имя проверяемого аргумента.</param>
        /// <exception cref="ArgumentNullException">Бросается, если <param name="source"> null или пуста.</param></exception>
        public static void AssertNotNullOrEmpty(this string source, string argumentName)
        {
            if (string.IsNullOrEmpty(source))
            {
                var exception = new ArgumentNullException(argumentName);
                throw exception;
            }
        }

    }
}
