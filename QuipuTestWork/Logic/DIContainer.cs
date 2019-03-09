using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    ///     Абстрактный контейнер dependency injection.
    /// </summary>
    public abstract class DIContainer
    {
        /// <summary>
        ///     Зарегистрировать.
        /// </summary>
        /// <param name="registeredType">Тип.</param>
        public abstract void Register(Type registeredType);

        /// <summary>
        ///     Зарегистрировать.
        /// </summary>
        /// <param name="interfaceType">Тип-интерфейс.</param>
        /// <param name="implementationType">Тип-реализация.</param>
        public abstract void Register(Type interfaceType, Type implementationType);

        /// <summary>
        ///     Зарегистрировать.
        /// </summary>
        /// <param name="interfaceType">Тип-интерфейс.</param>
        /// <param name="implementationType">Тип-реализация.</param>
        /// <param name="name">Имя</param>
        public abstract void Register(Type interfaceType, Type implementationType, string name);

        /// <summary>
        ///     Зарегистрировать.
        /// </summary>
        /// <typeparam name="TInterface">Тип-интерфейс.</typeparam>
        /// <typeparam name="TImplementation">Тип-реализация.</typeparam>
        public virtual void Register<TInterface, TImplementation>()
        {
            Register(typeof(TInterface), typeof(TImplementation));
        }

        /// <summary>
        ///     Зарегистрировать.
        /// </summary>
        /// <typeparam name="TInterface">Тип-интерфейс.</typeparam>
        /// <typeparam name="TImplementation">Тип-реализация.</typeparam>
        /// <param name="name">Имя.</param>
        public virtual void Register<TInterface, TImplementation>(string name)
        {
            Register(typeof(TInterface), typeof(TImplementation), name);
        }

        /// <summary>
        ///     Зарегистрировать екземпляр.
        /// </summary>
        /// <param name="registeredType">Тип.</param>
        /// <param name="instance">Экземпляр.</param>
        /// <param name="lifetime">Время жизни.</param>
        public abstract void RegisterInstance(Type registeredType, object instance, InstanceLifeTime lifetime);

        /// <summary>
        ///     Разрешить.
        /// </summary>
        /// <param name="serviceType">Тип-интерфейс.</param>
        /// <param name="name">Имя.</param>
        /// <returns>Экземпляр реализации.</returns>
        public abstract object Resolve(Type serviceType, string name);

        /// <summary>
        ///     Разрешить.
        /// </summary>
        /// <param name="serviceType">Тип-интерфейс.</param>
        /// <returns>Экземпляр реализации.</returns>
        public abstract object Resolve(Type serviceType);

        /// <summary>
        ///     Разрешить.
        /// </summary>
        /// <typeparam name="T">Тип.</typeparam>
        /// <returns>
        ///     Экземпляр типа <typeparamref name="T" />.
        /// </returns>
        public virtual T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        /// <summary>
        ///     Разрешить.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <typeparam name="T">Тип.</typeparam>
        /// <returns>
        ///     Экземпляр типа <typeparamref name="T" />.
        /// </returns>
        public virtual T Resolve<T>(string name)
        {
            return (T)Resolve(typeof(T), name);
        }

        /// <summary>
        ///     Получить экземпляры всех реализаций.
        /// </summary>
        /// <param name="serviceType">Тип-интерфейс.</param>
        /// <returns>Экземпляры всех реализаций.</returns>
        public abstract IEnumerable<object> ResolveAll(Type serviceType);

        /// <summary>
        ///     Разрешить все.
        /// </summary>
        /// <typeparam name="T">Тип.</typeparam>
        /// <returns>
        ///     Все реализации <typeparamref name="T" />.
        /// </returns>
        public virtual IEnumerable<T> ResolveAll<T>()
        {
            return ResolveAll(typeof(T)).Cast<T>();
        }
    }
}
