using Ookii.Dialogs.Wpf;

namespace Logic
{
    /// <inheritdoc />
    public class DialogService : IDialogService
    {
        /// <inheritdoc />
        public string OpenFileDialog()
        {
            VistaOpenFileDialog dlg = new VistaOpenFileDialog();
            return dlg.ShowDialog() == true ? dlg.FileName : string.Empty;
        }
    }
}
