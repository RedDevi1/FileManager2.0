using System;
using System.Configuration;
using System.IO;
using FilesAndDirectoriesOperations;
using FilesAndDirectoriesOperations.Models;
using FilesAndDirectoriesOperations.Commands;
using FilesAndDirectoriesOperations.Window;

namespace FileManager2._0
{
    public class Program
    {
        //public static FileModel CurrentFile { get; set; }
        //public static DirectoryModel CurrentDirectory { get; set; }
        static void Main(string[] args)
        {
            Console.Title = "ФАЙЛОВЫЙ МЕНЕДЖЕР 2.0. Автор: Дернов Никита";
            Configuration roaming = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoaming);
            var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = roaming.FilePath };
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            string curPath = null;
            if (config.AppSettings.Settings.Count == 0)
            {
                curPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // задаем путь по умолчанию при первом запуске приложения
            }
            else
            {
                curPath = config.AppSettings.Settings["CurrentPath"].Value;
            }
            DirectoryModel currentDirectory = new (curPath);
            FileModel currentFile = new(curPath);
            var numOfPage = 1;
            Page currentPage = new (currentDirectory, numOfPage);
            currentPage.Print();
            TUI.Draw(Console.BufferWidth);
            //bool exit = false;
            CheckExit exit = new();
            exit.Exit = false;
            //while (!exit)
            while (!exit.Exit)
            {
                GetCommand.CatchCommand(currentDirectory, currentFile, currentPage, ref config, ref exit);
            }
        }        
    }
}
