using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndDirectoriesOperations.Commands
{
    public class ExitCommand : FileManagerCommand
    {
        private Configuration config;
        private Models.DirectoryModel content;
        private bool exit;
        public bool Exit 
        {
            get => exit;
            set => exit = value; 
        }
        public ExitCommand(ref Configuration config, Models.DirectoryModel content, ref bool exit)
        {
            Name = "Exit";
            Description = "Exit of the application";
            this.config = config;
            this.content = content;
            exit = this.exit;
        }
        public override void RunCommand()
        {
            try
            {
                if (config.AppSettings.Settings.Count == 0)
                    config.AppSettings.Settings.Add("CurrentPath", content.FullName);
                else
                    config.AppSettings.Settings["CurrentPath"].Value = content.FullName;
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Ошибка чтения файла конфигурации приложения");
            }
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
            Exit = true;
        }
    }
}
