using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndDirectoriesOperations.Commands
{
    internal class AddNewFolderCommand : FileManagerCommand
    {
        private string dirPath;
        private Models.DirectoryModel dir;
        public AddNewFolderCommand(Models.DirectoryModel content, string dirPath)
        {
            Name = "AddNewFolder";
            Description = "Add new folder in the current directory";
            this.dirPath = dirPath;
            dir = content;
        }
        public override void RunCommand()
        {
            try
            {
                dir = new(dirPath);
                if (dir.Exist)
                {
                    Console.WriteLine("По заданному пути папка уже существует");
                    return;
                }
                dir.Create();
                Console.WriteLine("Папка успешно создана по заданному пути");
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка при создании новой директории: {0}", e.ToString());
            }
        }
    }
}
