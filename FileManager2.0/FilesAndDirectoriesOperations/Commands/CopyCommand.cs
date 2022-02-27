using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndDirectoriesOperations.Commands
{
    public class CopyCommand : FileManagerCommand
    {
        string target;
        string source;
        public CopyCommand(string target, string source)
        {
            Name = "Copy";
            Description = "Copy file or directory";
            this.target = target;
            this.source = source;
        }
        public override void RunCommand()
        {
            try
            {
                Models.DirectoryModel sourceDir = new(source);
                Models.FileModel sourceFile = new(source);
                if (sourceDir.Exist)
                {
                    Models.DirectoryModel targetDir = new(target);
                    if (sourceDir.Name == targetDir.Name)
                    {
                        Console.WriteLine("Папка с именем {0} уже существует, хотите ее заменить?(да/нет)", sourceDir.Name);
                        if (Console.ReadLine() == "да")
                        {
                            targetDir.DeleteDirectory();
                            sourceDir.CopyDir(sourceDir.FullName, target);
                        }
                        else if (Console.ReadLine() == "нет")
                        {
                            var newFullPathOfDirectory = new StringBuilder(sourceDir.FullName).Append("(1)").ToString();
                            sourceDir.CopyDir(sourceDir.FullName, newFullPathOfDirectory);
                        }
                    }
                    else
                    {
                        sourceDir.CopyDir(sourceDir.FullName, target);
                    }
                }
                else if (sourceFile.Exist)
                {
                    Models.FileModel targetFile = new(target);
                    if (sourceFile.Name == targetFile.Name)
                    {
                        Console.WriteLine("Файл с именем {0} уже существует, хотите его заменить?(да/нет)", sourceFile.Name);
                        if (Console.ReadLine() == "да")                       
                            sourceFile.CopyFile(target);
                        else if (Console.ReadLine() == "нет")
                        {
                            var newNameOfFile = Path.GetFileNameWithoutExtension(target) + "(1)";
                            var newFullPathOfFile = new StringBuilder(sourceFile.NameOfDirectory)
                                .Append("\\" + newNameOfFile + Path.GetExtension(target)).ToString();
                            sourceFile.CopyFile(newFullPathOfFile);
                        }
                    }
                    else
                        sourceFile.CopyFile(target);
                }
                else
                    Console.WriteLine("Неверно указан путь источника");
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка при выполнении команды \"copy\": {0}", e.ToString());
            }
        }
    }
}
