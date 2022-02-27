using System;
using System.Configuration;

namespace FilesAndDirectoriesOperations.Commands
{
    public static class CommandParser
    {
        public static void Parse(Models.DirectoryModel content, Models.FileModel currentFile, string userInput, string[] usrCmd, Page currentPage, ref Configuration config, ref bool exit)
        {
            if (userInput is null)
                throw new ArgumentNullException("Пользовательский ввод пуст", nameof(userInput));
            var parsePath = userInput.Split('"');
            switch (usrCmd[0])
            {
                case "exit":
                    new ExitCommand(ref config, content, ref exit).RunCommand();
                    break;
                case "md":
                    if (parsePath.Length != 3)
                    {
                        Console.WriteLine("Неверно задан путь к новой директории");
                        break;
                    }                            
                    new AddNewFolderCommand(content, parsePath[1]).RunCommand();
                    break;
                case "mf":
                    if (parsePath.Length != 3)
                    {
                        Console.WriteLine("Неверно задан путь к новому файлу");
                        break;
                    }
                    new AddNewFileCommand(currentFile, parsePath[1]).RunCommand();
                    break;
                case "cd":
                    if (parsePath.Length != 3)
                    {
                        Console.WriteLine("Неверно задан путь");
                        break;
                    }
                    new ChangeDirectoryCommand(content, currentPage, parsePath[1]).RunCommand();
                    break;
                case "move":
                    if (parsePath.Length != 5)
                    {
                        Console.WriteLine("Неверно заданы пути");
                        break;
                    }
                    new MoveCommand(parsePath[1], parsePath[3]).RunCommand();
                    break;
                case "rd":
                    if (parsePath.Length != 3)
                    {
                        Console.WriteLine("Неверно задан путь");
                        break;
                    }
                    new DeleteFolderCommand(parsePath[1]).RunCommand();
                    break;
                case "rf":
                    if (parsePath.Length != 3)
                    {
                        Console.WriteLine("Неверно задан путь");
                        break;
                    }
                    new DeleteFileCommand(parsePath[1]).RunCommand();
                    break;
                case "ren":
                    if (parsePath.Length != 3)
                    {
                        Console.WriteLine("Неверно задан путь");
                        break;
                    }
                    new RenameCommand(parsePath[1]).RunCommand();
                    break;
                case "cp":
                    if (parsePath.Length != 5)
                    {
                        Console.WriteLine("Неверно заданы пути");
                        break;
                    }
                    new CopyCommand(parsePath[1], parsePath[3]).RunCommand();
                    break;
                case "pg":
                    var exitProcess = false;
                    while (!exitProcess)
                    {
                        var userKey = Console.ReadKey();
                        if (userKey.Key != ConsoleKey.Q)
                            currentPage.Paging(userKey);
                        else                       
                            exitProcess = true;                   
                    }
                    break;
                case "info":
                    if (parsePath.Length != 3)
                    {
                        Console.WriteLine("Неверно задан путь");
                        break;
                    }
                    new InfoCommand(parsePath[1]).RunCommand();
                    break;
            }
        }
    }
}
