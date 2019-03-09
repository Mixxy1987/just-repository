using System;
using System.Threading;
using System.Windows.Threading;
using Common.Extensions;

namespace QuipuTestWork.Common
{
    public sealed class UiContext : IUiContext
    {
        private readonly Dispatcher _dispatcher;

        /// <inheritdoc />
        public bool IsSynchronized => _dispatcher.Thread == Thread.CurrentThread;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="dispatcher">Диспетчер.</param>
        public UiContext(Dispatcher dispatcher)
        {
            dispatcher.AssertNotNull("dispatcher");
            this._dispatcher = dispatcher;
        }

        /// <inheritdoc />
        public void Invoke(Action action)
        {
            action.AssertNotNull("action");
            _dispatcher.Invoke(action);
        }

        /// <inheritdoc />
        public void BeginInvoke(Action action)
        {
            action.AssertNotNull("action");
            _dispatcher.BeginInvoke(action);
        }
    }
}
