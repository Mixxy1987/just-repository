using Ookii.Dialogs.Wpf;

namespace Logic
{
    /// <inheritdoc />
    public class DialogService : IDialogService
    {
        public string OpenFileDialog(string path)
        {
            VistaOpenFileDialog dlg = new VistaOpenFileDialog();
            return dlg.ShowDialog() == true ? dlg.FileName : string.Empty;
        }
    }
}
