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
        /// Проверить существование директории.
        /// </summary>
        /// <param name="path">Путь.</param>
        /// <returns>True если директория существует, иначе False.</returns>
        bool Exists(string path);

        /// <summary>
        /// Получить текущую директорию.
        /// </summary>
        /// <returns>Текущая директория.</returns>
        string GetCurrentDirectory();

        /// <summary>
        /// Получить текущую для исполняемого файла директорию.
        /// </summary>
        /// <returns>Текущая директория файла.</returns>
        string GetCurrentApplicationDirectory();

        /// <summary>
        /// Получить директорию по пути.
        /// </summary>
        /// <param name="path">Путь.</param>
        /// <returns>Директория.</returns>
        string GetDirectoryFromPath(string path);

        /// <summary>
        /// Получить системную специальную директорию.
        /// </summary>
        /// <param name="id">Уникальный id директории.</param>
        /// <returns>Директория.</returns>
        string GetSpecialDirectory(Environment.SpecialFolder id);

        string GetFullPath(string path);
        bool ValidatePath(string path);
        IEnumerable<string> ReadFileContent(string path);

    }
}
