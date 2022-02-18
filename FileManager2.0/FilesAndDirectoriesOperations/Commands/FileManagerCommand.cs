using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndDirectoriesOperations.Commands
{
    public abstract class FileManagerCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public abstract void RunCommand();
    }
}
