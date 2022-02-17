using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndDirectoriesOperations
{
    public class DirectoryModel
    {
        
        private readonly DirectoryInfo _Directory;
        public string Name => _Directory.Name;
        public string FullName => _Directory.FullName;
        public bool Exist => _Directory.Exists;
        public DirectoryModel(string DirectoryPath) : this(new DirectoryInfo(DirectoryPath))
        { }
        public DirectoryModel(DirectoryInfo Directory) => _Directory = Directory;
        public IEnumerable<DirectoryInfo> EnumerateDirectories (string? Mask = null)
        {
            if (Mask is null)
                return _Directory.EnumerateDirectories();
            return _Directory.EnumerateDirectories(Mask);
        }
        public IEnumerable<FileInfo> EnumerateFiles(string? Mask = null)
        {
            if (Mask is null)
                return _Directory.EnumerateFiles();
            return _Directory.EnumerateFiles(Mask);
        }
    }
}
