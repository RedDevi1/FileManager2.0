using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndDirectoriesOperations.Commands
{
    class RenameCommand : FileManagerCommand
    {
        private string path;
        public RenameCommand(string path)
        {
            Name = "Rename";
            Description = "Rename file or folder";
            this.path = path;
        }
        public override void RunCommand()
        {
            try
            {
                Models.DirectoryModel dir = new(path);
                Models.FileModel file = new(path);
                if (dir.Exist)
                {
                    Console.WriteLine("Введите новое имя для папки {0}", dir.Name);
                    var newName = Console.ReadLine();
                    if (newName is not null)
                    {
                        var newFullPathOfDirectory = new StringBuilder(dir.Parent).Append("\\" + newName).ToString();
                        dir.MoveDir(newFullPathOfDirectory);
                    }
                }
                else if (file.Exist)
                {
                    Console.WriteLine("Введите новое имя для файла {0} без расширения", file.Name);
                    var newName = Console.ReadLine();
                    if (newName is not null)
                    {
                        var newFullPathOfFile = new StringBuilder(file.NameOfDirectory)
                                    .Append("\\" + newName + Path.GetExtension(path)).ToString();
                        file.MoveFile(newFullPathOfFile);
                    }
                }
                else
                    Console.WriteLine("Неверно указан путь");
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка при выполнении команды \"rename\": {0}", e.ToString());
            }
        }
    }
}
