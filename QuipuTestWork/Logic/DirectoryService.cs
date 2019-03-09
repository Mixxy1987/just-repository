using System;
using System.Collections.Generic;
using System.IO;

namespace Logic
{
    /// <inheritdoc />
    public class DirectoryService : IDirectoryService
    {
        /// <inheritdoc />
        public bool Exists(string path)
        {
            return Directory.Exists(path);
        }

        /// <inheritdoc />
        public string GetCurrentDirectory()
        {
            return Directory.GetCurrentDirectory();
        }

        /// <inheritdoc />
        public string GetCurrentApplicationDirectory()
        {
            return Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        }

        /// <inheritdoc />
        public string GetDirectoryFromPath(string path)
        {
            return Path.GetDirectoryName(path);
        }

        /// <inheritdoc />
        public string GetSpecialDirectory(Environment.SpecialFolder id)
        {
            return Environment.GetFolderPath(id);
        }

        public string GetFullPath(string path)
        {
            return Path.GetFullPath(path);
        }

        public bool ValidatePath(string path)
        {
            return !string.IsNullOrEmpty(path)
                           && Directory.Exists(Path.GetDirectoryName(path))
                           && File.Exists(path);
        }

        public IEnumerable<string> ReadFileContent(string path)
        {
            return File.ReadLines(path);
        }
    }
}
