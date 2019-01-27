using System;

namespace GeometrySteps.Logic
{
    /// <summary>
    /// Реализация Monada MayBe.
    /// </summary>
    /// <typeparam name="T">Тип значения.</typeparam>
    public sealed class Option<T>
    {
        private static readonly Option<T> empty = new Option<T>(default(T), false);
        private readonly bool hasValue;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <param name="hasValue">Установлено ли значение.</param>
        public Option(T value, bool hasValue = true)
        {
            this.hasValue = hasValue;
            Value = value;
        }

        /// <summary>
        /// Экземпляр без значения.
        /// </summary>
        public static Option<T> Empty => empty;

        /// <summary>
        /// Значение не установлено.
        /// </summary>
        public bool HasNoValue => !hasValue;

        /// <summary>
        /// Значение установлено.
        /// </summary>
        public bool HasValue => hasValue;

        /// <summary>
        /// Значение.
        /// </summary>
        public T Value { get; private set; }

        /// <summary>
        /// Выполнение действия при условии истинности предиката.
        /// </summary>
        /// <param name="predicate">Предикат.</param>
        /// <param name="action">Действие.</param>
        /// <returns>Текущий объект.</returns>
        public Option<T> Match(Func<T, bool> predicate, Action<T> action)
        {
            if (HasNoValue)
            {
                return Empty;
            }
            if (predicate(Value) == false)
            {
                return this;
            }
            action(Value);
            return this;
        }

        /// <summary>
        /// Выполнение действия при совпадения типов.
        /// </summary>
        /// <typeparam name="TTarget">Тип.</typeparam>
        /// <param name="action">Действие.</param>
        /// <returns>Текущий объект.</returns>
        public Option<T> MatchType<TTarget>(Action<TTarget> action)
            where TTarget : T
        {
            if (HasNoValue)
            {
                return Empty;
            }
            if (Value.GetType() == typeof(TTarget))
            {
                action((TTarget)Value);
            }
            return this;
        }

        /// <summary>
        /// Инициировать исключение, если значение пусто.
        /// </summary>
        /// <typeparam name="TException">Тип исключения.</typeparam>
        /// <returns>Текущий объект.</returns>
        public Option<T> ThrowOnEmpty<TException>()
            where TException : Exception, new()
        {
            if (HasValue)
            {
                return this;
            }
            throw new TException();
        }

        /// <summary>
        /// Инициировать исключение, если значение пусто.
        /// </summary>
        /// <typeparam name="TException">Тип исключения.</typeparam>
        /// <param name="func">Функция, генерирующая исключение.</param>
        /// <returns>Текущий объект.</returns>
        public Option<T> ThrowOnEmpty<TException>(Func<TException> func)
            where TException : Exception
        {
            if (HasValue)
            {
                return this;
            }
            throw func();
        }
    }
}
