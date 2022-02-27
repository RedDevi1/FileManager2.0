using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndDirectoriesOperations.Commands
{
    class AddNewFileCommand : FileManagerCommand
    {
        private string filePath;
        private Models.FileModel currentFile;
        public AddNewFileCommand (Models.FileModel currentFile, string filePath)
        {
            Name = "AddNewFile";
            Description = "Add new file in the current directory";
            this.currentFile = currentFile;
            this.filePath = filePath;
        }
        public override void RunCommand()
        {
            try
            {
                currentFile = new(filePath);
                if (currentFile.Exist)
                {
                    Console.WriteLine("По заданному пути файл уже существует");
                    return;
                }
                currentFile.Create();
                Console.WriteLine("Файл успешно создан по заданному пути");
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка при создании нового файла: {0}", e.ToString());
            }
        }
    }
}
