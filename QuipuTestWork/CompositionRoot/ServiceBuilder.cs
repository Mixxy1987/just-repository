using Logic;
using QuipuTestWork.Common;

namespace CompositionRoot
{
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
            container.Register<IDirectoryService, DirectoryService>();
            container.Register<IDialogService, DialogService>();
            container.Register<IHttpApiBase, HttpApiBase>();
            container.Register<IHttpApi, HttpApi>();
            container.Register<IWebLoader, WebLoader>();
        }
    }
}
