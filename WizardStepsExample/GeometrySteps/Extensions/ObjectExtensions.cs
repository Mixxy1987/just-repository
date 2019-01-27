using GeometrySteps.Logic;

namespace GeometrySteps.Extensions
{
    /// <summary>
    /// Расширения для произвольного типа.
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Преобразовать в <see cref="Option{T}"/>.
        /// </summary>
        /// <typeparam name="T">Тип.</typeparam>
        /// <param name="value">Значение.</param>
        /// <returns>Объект <see cref="Option{T}"/>.</returns>
        public static Option<T> ToOption<T>(this T value)
        {
            if (typeof(T).IsValueType == false && ReferenceEquals(value, null))
            {
                return Option<T>.Empty;
            }
            return new Option<T>(value);
        }
    }
}
