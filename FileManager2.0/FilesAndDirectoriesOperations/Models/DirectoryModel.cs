using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndDirectoriesOperations.Models
{
    public class DirectoryModel : FileSystemModel
    {

        private readonly DirectoryInfo _Directory;
        public string Name => _Directory.Name;
        public string FullName => _Directory.FullName;
        public bool Exist => _Directory.Exists;
        public FileAttributes Attributes
        {
            get => _Directory.Attributes;
            set => _Directory.Attributes = value;
        }
        public long TotalSize => _Directory.EnumerateFiles("*.*", SearchOption.AllDirectories).Sum(f => f.Length);
        public DirectoryModel(string DirectoryPath) : this(new DirectoryInfo(DirectoryPath))
        { }
        public DirectoryModel(DirectoryInfo Directory) => _Directory = Directory;
        public IEnumerable<DirectoryInfo> EnumerateDirectories(string Mask = null)
        {
            if (Mask is null)
                return _Directory.EnumerateDirectories();
            return _Directory.EnumerateDirectories(Mask);
        }
        public IEnumerable<FileInfo> EnumerateFiles(string Mask = null)
        {
            if (Mask is null)
                return _Directory.EnumerateFiles();
            return _Directory.EnumerateFiles(Mask);
        }
        public IEnumerable<FileSystemInfo> EnumerateFileSystem(string Mask = null)
        {
            if (Mask is null)
                return _Directory.EnumerateFileSystemInfos();
            return _Directory.EnumerateFileSystemInfos(Mask);
        }
    }
}
