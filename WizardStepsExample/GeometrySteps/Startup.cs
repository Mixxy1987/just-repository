using System;
using System.Windows;
using Unity;
using GeometrySteps.Logic;
using GeometrySteps.Logic.Interfaces;

namespace GeometrySteps
{
    internal class Startup
    {
        private static readonly DIContainer container = new UnityDIContainer(new UnityContainer());

        [STAThread]
        private static void Main()
        {
            RegisterCommonDependencies();
            ConfigureAndStartApp();
        }

        private static void RegisterCommonDependencies()
        {
            var serviceBuilder = new ServiceBuilder(container);
            serviceBuilder.RegisterDependencies();
        }

        private static void ConfigureAndStartApp()
        {
            var app = new Application();
            RunApplication(app);
        }

        private static void RunApplication(Application app)
        {
            app.MainWindow = container.Resolve<MainWindow>();
            app.MainWindow.Show();
            app.Run();
        }
    }
}
