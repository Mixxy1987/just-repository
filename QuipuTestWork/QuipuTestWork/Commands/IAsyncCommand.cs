using System.Windows.Input;

namespace QuipuTestWork.Commands
{
    public interface IAsyncCommand : ICommand
    {
        bool IsCancellationRequested { get; }
        void Cancel();
    }
}
