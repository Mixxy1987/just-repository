using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuipuTestWork.Commands
{
    public class AsyncCommand : IAsyncCommand
    {
        private readonly Func<object, CancellationToken, Task> execute;
        private readonly Func<object, bool> canExecute;
        private bool isRunning = false;
        private CancellationTokenSource cancellationToken;

        public bool IsCancellationRequested => cancellationToken?.IsCancellationRequested ?? false;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public AsyncCommand(Func<object, CancellationToken, Task> execute)
        {
            this.execute = execute;
            canExecute = (param) => true;
        }

        public AsyncCommand(Func<object, CancellationToken, Task> execute, Func<object, bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute(parameter) && !isRunning;
        }

        public void Execute(object parameter)
        {
            isRunning = true;
            cancellationToken = new CancellationTokenSource();
            var taskResult = Await(parameter);
            isRunning = false;
            CommandManager.InvalidateRequerySuggested();
        }

        private async Task Await(object parameter)
        {
            await execute(parameter, cancellationToken.Token);
        }

        public void Cancel()
        {
            cancellationToken.Cancel();
        }
    }
}
