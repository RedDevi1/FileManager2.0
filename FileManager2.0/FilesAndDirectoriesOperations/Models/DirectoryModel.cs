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
        public string Parent => _Directory.Parent.FullName;
        public bool Exist => _Directory.Exists;
        public FileAttributes Attributes
        {
            get => File.GetAttributes(_Directory.FullName);
            set => File.SetAttributes(_Directory.FullName, Attributes);
        }
        //public FileSystemInfo Info => _Directory.CreationTime;
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
        public void Create()
        {
            _Directory.Create();
        }
        public void MoveDir(string targetPath)
        {
            try
            {
                DirectoryInfo TargetDir = new(targetPath);
                if (!TargetDir.Exists)
                    TargetDir.Create();
                DirectoryInfo SubTargetDir = TargetDir.CreateSubdirectory(targetPath);
                _Directory.MoveTo(SubTargetDir.FullName);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка при выполнении \"move\": {0}", e.ToString());
            }
        }
        public void DeleteDirectory()
        {
            try
            {
                _Directory.Delete(true);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка при попытке удаления папки: {0}", e.ToString());
            }
        }
        public void CopyDir(string sourcePath, string targetPath)
        {
            try
            {
                DirectoryInfo SourceDir = new(sourcePath);
                DirectoryInfo TargetDir = new(targetPath);
                DirectoryInfo[] dirs = SourceDir.GetDirectories();
                if (!TargetDir.Exists)
                    TargetDir.Create();
                FileInfo[] files = SourceDir.GetFiles();
                foreach (FileInfo file in files)
                {
                    string temppath = Path.Combine(targetPath, file.Name);
                    file.CopyTo(temppath, true);
                }

                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(targetPath, subdir.Name);
                    CopyDir(subdir.FullName, temppath);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка при выполнении \"copy\": {0}", e.ToString());
            }
        }
    }
}
