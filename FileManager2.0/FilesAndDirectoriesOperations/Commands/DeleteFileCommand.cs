using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndDirectoriesOperations.Commands
{
    class DeleteFileCommand : FileManagerCommand
    {
        private string filePath;
        public DeleteFileCommand(string filePath)
        {
            Name = "DeleteFile";
            Description = "Delete file";
            this.filePath = filePath;
        }
        public override void RunCommand()
        {
            try
            {
                Models.FileModel file = new(filePath);
                if (file.Exist)
                {
                    Console.WriteLine("Вы действительно хотите удалить файл {0} безвозвратно?(да/нет)", file.Name);
                    if (Console.ReadLine() == "да")
                        file.DeleteFile();
                }
                else
                {
                    Console.WriteLine("Неверно указан путь к файлу");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка при попытке удаления файла: {0}", e.ToString());
            }
        }
    }
}
