using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndDirectoriesOperations.Commands
{
    class RenameFileCommand : FileManagerCommand
    {
        public RenameFileCommand()
        {
            Name = "RenameFile";
            Description = "Rename file";
        }
        public override void RunCommand()
        {

        }
    }
}
