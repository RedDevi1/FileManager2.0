using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndDirectoriesOperations
{
    public class Page
    {
        private Models.DirectoryModel content;
        private int numOfPage;
        private int numOfStringsPerPage = 20;
        public int NumOfPage { get; set; }
        public int NumOfStringsPerPage => numOfStringsPerPage;
        public int NumOfAllPages
        {
            get
            {
                return (int)Math.Ceiling((decimal)content.EnumerateFileSystem().Count() / numOfStringsPerPage);
            }
        }

        public Page(Models.DirectoryModel content, int numOfPage)
        {
            this.content = content;
            this.numOfPage = numOfPage;
        }
        private FileSystemInfo[] GetContentPerPage()
        {
            var contentPerPage = content.EnumerateFileSystem()
                .Skip((numOfPage - 1) * numOfStringsPerPage)
                .Take(numOfStringsPerPage)
                .ToArray();
            return contentPerPage;
        }
        public void Print()
        {
            Console.Clear();
            Console.WriteLine("======= Текущая директория: {0} =======", content.FullName);
            Console.WriteLine();
            var contentForPrint = GetContentPerPage();
            for (var i = 0; i < contentForPrint.Length; i++)
                Console.WriteLine("\t{0}",contentForPrint[i]);
            //Console.SetCursorPosition(0, 24);
            Console.WriteLine();
            Console.WriteLine("======= Номер страницы: {0} ==================================", this.numOfPage);
            Console.WriteLine();
            Window.TUI.MenuHelp();
        }
        public void Paging(ConsoleKeyInfo userKey)
        {
            if (userKey.Key == ConsoleKey.RightArrow)
            {
                if (this.numOfPage < NumOfAllPages)
                {
                    this.numOfPage += 1;
                    Print();
                }
            }
            if (userKey.Key == ConsoleKey.LeftArrow)
            {
                if (this.numOfPage > 1)
                {
                    this.numOfPage -= 1;
                    Print();
                }
            }
        }
    }
}
