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
        private CheckExit exit;
        public ExitCommand(ref Configuration config, Models.DirectoryModel content, ref CheckExit exit)
        {
            Name = "Exit";
            Description = "Exit of the application";
            this.config = config;
            this.content = content;
            this.exit = exit;
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
            this.exit.Exit = true;
        }
    }
}
