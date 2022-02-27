using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndDirectoriesOperations.Commands
{
    class DeleteFolderCommand : FileManagerCommand
    {
        private string dirPath;
        public DeleteFolderCommand(string dirPath)
        {
            Name = "DeleteFolder";
            Description = "Delete folder";
            this.dirPath = dirPath;
        }
        public override void RunCommand()
        {
            try
            {
                Models.DirectoryModel dir = new(dirPath);
                if (dir.Exist)
                {
                    Console.WriteLine("Вы действительно хотите удалить папку {0} безвозвратно?(да/нет)", dir.Name);
                    if (Console.ReadLine() == "да")
                        dir.DeleteDirectory();
                }
                else
                {
                    Console.WriteLine("Неверно указан путь к папке");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка при попытке удаления папки: {0}", e.ToString());
            }
        }
    }
}
