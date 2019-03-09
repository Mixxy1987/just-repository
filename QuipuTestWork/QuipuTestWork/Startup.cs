using System;
using System.Windows;
using System.Windows.Threading;
using CompositionRoot;
using Logic;
using Unity;

namespace QuipuTestWork
{
    internal class Startup
    {
        private static readonly DIContainer container = new UnityDIContainer(new UnityContainer());

        private static void ConfigureAndStartApp()
        {
            var app = new Application();
            SubscribeToUnhandledExceptionEvent(app);
            RunApplication(app);
        }

        private static void DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            Environment.Exit(0);
        }

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

        private static void RunApplication(Application app)
        {
            app.MainWindow = container.Resolve<MainWindow>();
            app.MainWindow.Show();
            app.Run();
        }

        private static void SubscribeToUnhandledExceptionEvent(Application app)
        {
            app.DispatcherUnhandledException += DispatcherUnhandledException;
        }
    }
}
