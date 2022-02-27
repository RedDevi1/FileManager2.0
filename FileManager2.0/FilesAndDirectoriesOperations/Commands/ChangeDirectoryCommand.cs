using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndDirectoriesOperations.Commands
{
    class ChangeDirectoryCommand : FileManagerCommand
    {
        private string dirPath;
        private Models.DirectoryModel dir;
        private Page currentPage;
        public ChangeDirectoryCommand(ref Models.DirectoryModel content, Page currentPage, string dirPath)
        {
            Name = "ChangeDirectory";
            Description = "Change current directory";
            this.dirPath = dirPath;
            content = new(dirPath);
            dir = content;
            this.currentPage = currentPage;
        }
        public override void RunCommand()
        {
            try
            {
                Console.Clear();              
                currentPage = new(dir, 1);
                currentPage.Print();
                Window.TUI.Draw(Console.BufferWidth);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка при попытке сменить директорию: {0}", e.ToString());
            }
        }
    }
}
