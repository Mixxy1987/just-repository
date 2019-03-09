namespace Logic
{
    /// <summary>
    /// Создание диалогов.
    /// </summary>
    public interface IDialogService
    {
        /// <summary>
        /// Диалог открытия файла.
        /// </summary>
        /// <returns>Путь к файлу.</returns>
        string OpenFileDialog();  // открытие файла
    }
}
