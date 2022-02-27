using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndDirectoriesOperations.Commands
{
    class InfoCommand : FileManagerCommand
    {
        private string path;
        public InfoCommand(string path)
        {
            Name = "Info";
            Description = "Show attributes of a file or directory";
            this.path = path;
        }
        public override void RunCommand()
        {
            Models.DirectoryModel dir = new(path);
            if (dir.Exist)
            {
                var attributes = dir.Attributes;
                
            }
        }
    }
}
