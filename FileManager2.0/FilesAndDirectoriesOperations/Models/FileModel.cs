using System;
using System.Configuration;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndDirectoriesOperations.Models
{
    public class FileModel : FileSystemModel
    {
        private readonly FileInfo _File;
        public string Name => _File.Name;
        public string Extension => _File.Extension;
        public string FullName => _File.FullName;
        public bool IsReadOnly => _File.IsReadOnly;
        public bool Exist => _File.Exists;
        public FileAttributes Attributes
        {
            get => File.GetAttributes(_File.FullName);
            set => File.SetAttributes(_File.FullName, Attributes);
        }
        public string NameOfDirectory => _File.DirectoryName;
        public FileModel(string FilePath) : this(new FileInfo(FilePath))
        { }
        public FileModel(FileInfo File) => _File = File;
        public void Create()
        {
            _File.Create();
        }
        public void MoveFile(string targetPath)
        {
            try
            {
                _File.MoveTo(targetPath);              
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка при попытке перемещения файла: {0}", e.ToString());
            }
        }
        public void DeleteFile()
        {
            try
            {
                _File.Delete();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка при попытке удаления файла: {0}", e.ToString());
            }
        }
        public void CopyFile(string targetPath)
        {
            try
            {
                _File.CopyTo(targetPath, true);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка при попытке скопировать файл: {0}", e.ToString());
            }
        }
    }
}
