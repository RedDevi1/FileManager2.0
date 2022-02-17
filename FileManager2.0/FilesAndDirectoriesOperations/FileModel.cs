using System;
using System.Configuration;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndDirectoriesOperations
{
    public class FileModel
    {
        private readonly FileInfo _File;
        public string Name => _File.Name;
        public string Extension => _File.Extension;
        public string FullName => _File.FullName;
        public bool IsReadOnly => _File.IsReadOnly;
        public bool Exist => _File.Exists;
        public string NameOfDirectory => _File.DirectoryName;
        public FileModel(string FilePath) : this (new FileInfo(FilePath))
        { }
        public FileModel(FileInfo File) => _File = File;

        
    }
}
