using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndDirectoriesOperations.Commands
{
    enum AllCommands {exit, pg, cd, cp, md, mf, move, dinfo, finfo, rd, rf, ren }
    public static class GetCommand
    {       
        public static void CatchCommand(ref Models.DirectoryModel content, Models.FileModel currentFile, Page currentPage, ref Configuration config, ref CheckExit exit)
        {
            bool rightCmd = false;
            string userInput;
            string[] usrCmd = null;
            do
            {
                userInput = Console.ReadLine();
                if (userInput != null)
                {
                    usrCmd = userInput.Split(' ');
                    Type commands = typeof(AllCommands);
                    foreach (var command in Enum.GetNames(commands))
                    {
                        if (usrCmd[0].ToLower().Trim() != command)
                            continue;
                        else
                        {
                            rightCmd = true;
                            break;
                        }                       
                    }
                    if (!rightCmd)
                        Console.WriteLine("Неизвестная команда, введите команду из списка команд");
                }
            }
            while (rightCmd == false);
            CommandParser.Parse(ref content, currentFile, userInput, usrCmd, currentPage, ref config, ref exit);
        }
    }
}
