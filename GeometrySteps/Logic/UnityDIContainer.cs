using System;
using System.Collections.Generic;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using GeometrySteps.Extensions;
using GeometrySteps.Logic.Interfaces;

namespace GeometrySteps.Logic
{
    /// <summary>
    ///     Контейнер dependency injection на основе Unity.
    /// </summary>
    public sealed class UnityDIContainer : DIContainer
    {
        private readonly IUnityContainer unityContainer;


        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="unityContainer">Конкретный контейнер.</param>
        public UnityDIContainer(IUnityContainer unityContainer)
        {
            this.unityContainer = unityContainer;
        }


        /// <summary>
        ///     Зарегистрировать.
        /// </summary>
        /// <param name="registeredType">Тип.</param>
        public override void Register(Type registeredType)
        {
            registeredType.AssertNotNull("registeredType");
            unityContainer.RegisterType(registeredType);
        }


        /// <summary>
        ///     Зарегистрировать.
        /// </summary>
        /// <param name="interfaceType">Тип-интерфейс.</param>
        /// <param name="implementationType">Тип-реализация.</param>
        public override void Register(Type interfaceType, Type implementationType)
        {
            interfaceType.AssertNotNull("interfaceType");
            implementationType.AssertNotNull("implementationType");
            unityContainer.RegisterType(interfaceType, implementationType);
        }


        /// <summary>
        ///     Зарегистрировать.
        /// </summary>
        /// <param name="interfaceType">Тип-интерфейс.</param>
        /// <param name="implementationType">Тип-реализация.</param>
        /// <param name="name">Имя</param>
        public override void Register(Type interfaceType, Type implementationType, string name)
        {
            interfaceType.AssertNotNull("interfaceType");
            implementationType.AssertNotNull("implementationType");
            name.AssertNotNullOrEmpty("name");

            unityContainer.RegisterType(interfaceType, implementationType, name);
        }


        /// <summary>
        ///     Зарегистрировать.
        /// </summary>
        /// <typeparam name="TC1">Тип первого параметра конструктора.</typeparam>
        /// <typeparam name="TC2">Тип второго параметра конструктора.</typeparam>
        /// <typeparam name="TC3">Тип третьего параметра конструктора.</typeparam>
        /// <param name="interfaceType">Тип-интерфейс.</param>
        /// <param name="implementationType">Тип-реализация.</param>
        /// <param name="name">Имя.</param>
        /// <param name="param1">Первый параметр конструктора.</param>
        /// <param name="param2">Второй параметр конструктора.</param>
        /// <param name="param3">Третий параметр конструктора.</param>
        public void Register<TC1, TC2, TC3>(
            Type interfaceType, Type implementationType, string name, TC1 param1, TC2 param2, TC3 param3)
        {
            interfaceType.AssertNotNull("interfaceType");
            implementationType.AssertNotNull("implementationType");
            name.AssertNotNullOrEmpty("name");

            unityContainer.RegisterType(
                interfaceType, implementationType, name, new InjectionConstructor(param1, param2, param3));
        }


        /// <summary>
        ///     Зарегистрировать екземпляр.
        /// </summary>
        /// <param name="registeredType">Тип.</param>
        /// <param name="instance">Экземпляр.</param>
        /// <param name="lifetime">Время жизни.</param>
        public override void RegisterInstance(Type registeredType, object instance, InstanceLifeTime lifetime)
        {
            registeredType.AssertNotNull("registeredType");
            instance.AssertNotNull("instance");

            if (lifetime == InstanceLifeTime.Singleton)
            {
                unityContainer.RegisterInstance(registeredType, instance, new ContainerControlledLifetimeManager());
            }
        }


        /// <summary>
        ///     Разрешить.
        /// </summary>
        /// <param name="serviceType">Тип-интерфейс.</param>
        /// <returns>Экземпляр реализации.</returns>
        public override object Resolve(Type serviceType)
        {
            serviceType.AssertNotNull("serviceType");
            return unityContainer.Resolve(serviceType);
        }


        /// <summary>
        ///     Разрешить.
        /// </summary>
        /// <param name="serviceType">Тип-интерфейс.</param>
        /// <param name="name">Имя.</param>
        /// <returns>Экземпляр реализации.</returns>
        public override object Resolve(Type serviceType, string name)
        {
            serviceType.AssertNotNull("serviceType");
            name.AssertNotNullOrEmpty("name");
            return unityContainer.Resolve(serviceType, name);
        }


        /// <summary>
        ///     Получить экземпляры всех реализаций.
        /// </summary>
        /// <param name="serviceType">Тип-интерфейс.</param>
        /// <returns>Экземпляры всех реализаций.</returns>
        public override IEnumerable<object> ResolveAll(Type serviceType)
        {
            serviceType.AssertNotNull("serviceType");
            return unityContainer.ResolveAll(serviceType);
        }
    }
}
