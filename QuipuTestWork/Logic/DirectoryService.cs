using System;
using System.Collections.Generic;
using System.IO;

namespace Logic
{
    /// <inheritdoc />
    public class DirectoryService : IDirectoryService
    {
        /// <inheritdoc />
        public string GetSpecialDirectory(Environment.SpecialFolder id)
        {
            return Environment.GetFolderPath(id);
        }

        /// <inheritdoc />
        public bool ValidatePath(string path)
        {
            return !string.IsNullOrEmpty(path)
                           && Directory.Exists(Path.GetDirectoryName(path))
                           && File.Exists(path);
        }

        /// <inheritdoc />
        public IEnumerable<string> ReadFileContent(string path)
        {
            return File.ReadLines(path);
        }
    }
}
