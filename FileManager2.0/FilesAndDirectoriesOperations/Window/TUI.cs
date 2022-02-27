using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndDirectoriesOperations.Window
{
    public class TUI
    {
        private static readonly Dictionary<int, string> HorizontalLine = new();
       
        public static void Draw (int Count)
        {
            Console.SetCursorPosition(0, 40);
            if (HorizontalLine.TryGetValue(Count, out var str))
                Console.WriteLine(str);
            else
            {
                str = new string('=', Count);
                HorizontalLine[Count] = str;
                Console.WriteLine(str);
            }           
        }
        public static void MenuHelp()
        {
            Console.WriteLine("\tСписок команд: exit - выход, cd - смена директории,\r\n " +
                "\tpg - режим постраничного просмотра файлового каталога\r\n" +
                "\t(для выхода из постраничного режима нажать Q),\r\n" +
                "\tmd - создание папки, mf - создание файла,\r\n" +
                "\tmove - перемещение файла/папки\r\n" +
                "\tdinfo - инфо о папке, finfo - инфо о файле,\r\n" +
                "\trd - удаление папки, rf - удаление файла\r\n" +
                "\tren - переименование файла/папки, cp - копирование файла/папки\r\n" +
                "\tпосле всех команд, кроме \"pg\", \"move\", \"cp\"\r\n" +
                "\tчерез пробел в кавычках указывается полный путь к файлу/папке\r\n" +
                "\tпосле команд \"move\", \"cp\" через пробел\r\n" +
                "\tв кавычках указывается полный путь к файлу/папке источника\r\n" +
                "\tдалее через пробел в кавычках указывается\r\n\tполный путь к файлу/папке назначения");
        }
    }
}
