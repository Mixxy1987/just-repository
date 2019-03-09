using System;
using System.Collections.Generic;

namespace Logic
{
    /// <summary>
    /// Cервис работы с директориями.
    /// </summary>
    public interface IDirectoryService
    {
        /// <summary>
        /// Получить системную специальную директорию.
        /// </summary>
        /// <param name="id">Уникальный id директории.</param>
        /// <returns>Директория.</returns>
        string GetSpecialDirectory(Environment.SpecialFolder id);

        /// <summary>
        /// Проверка валидности пути к файлу.
        /// </summary>
        /// <param name="path">Путь к файлу.</param>
        /// <returns>Валиден или нет.</returns>
        bool ValidatePath(string path);

        /// <summary>
        /// Чтение содержимого файла.
        /// </summary>
        /// <param name="path">путь к файлу.</param>
        /// <returns>Содержимое файла.</returns>
        IEnumerable<string> ReadFileContent(string path);

    }
}
