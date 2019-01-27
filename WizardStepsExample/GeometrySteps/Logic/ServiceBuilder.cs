using GeometrySteps.Logic.Interfaces;

namespace GeometrySteps.Logic
{
    /// <summary>
    ///     Composition root.
    /// </summary>
    public sealed class ServiceBuilder : ICompositionRoot
    {
        private readonly DIContainer container;

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="container">DI контейнер.</param>
        public ServiceBuilder(DIContainer container)
        {
            this.container = container;
        }

        /// <summary>
        ///     Зарегистрировать зависимости.
        /// </summary>
        public void RegisterDependencies()
        {
            RegisterSelf();
        }


        private void RegisterSelf()
        {
            container.RegisterInstance(typeof(DIContainer), container, InstanceLifeTime.Singleton);
        }
    }
}
