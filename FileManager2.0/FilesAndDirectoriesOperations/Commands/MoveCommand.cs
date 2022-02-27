using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndDirectoriesOperations.Commands
{
    class MoveCommand : FileManagerCommand
    {       
        private string target;
        private string source;
        public MoveCommand(string target, string source)
        {
            Name = "Move";
            Description = "Move file or folder from the current directory to another";            
            this.target = target;
            this.source = source;
        }
        public override void RunCommand()
        {
            try
            {
                Models.DirectoryModel sourceDir = new (source);
                if (sourceDir.Exist)
                    sourceDir.MoveDir(target);
                else
                {
                    Models.FileModel sourceFile = new(source);
                    Models.FileModel targetFile = new(target);
                    if (sourceFile.Exist)
                    {
                        if (sourceFile.Name == targetFile.Name)
                        {
                            Console.WriteLine("Файл с именем {0} уже существует, хотите его заменить?(да/нет)", sourceFile.Name);
                            if (Console.ReadLine() == "да")
                            {
                                targetFile.DeleteFile();
                                sourceFile.MoveFile(target);
                            }
                            else if (Console.ReadLine() == "нет")
                            {
                                var newNameOfFile = Path.GetFileNameWithoutExtension(target) + "(1)";
                                var newFullPathOfFile = new StringBuilder(sourceFile.NameOfDirectory)
                                    .Append("\\" + newNameOfFile + Path.GetExtension(target)).ToString();
                                sourceFile.MoveFile(newFullPathOfFile);
                            }
                        }
                        else
                            sourceFile.MoveFile(target);
                    }                       
                    else
                        Console.WriteLine("Неверно указан путь источника");
                } 
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка при выполнении команды \"move\": {0}", e.ToString());
            }
        }
    }
}
