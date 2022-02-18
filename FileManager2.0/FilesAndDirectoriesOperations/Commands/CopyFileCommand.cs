using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndDirectoriesOperations.Commands
{
    class CopyFileCommand : FileManagerCommand
    {
        public CopyFileCommand()
        {
            Name = "CopyFile";
            Description = "Copy file";
        }
        public override void RunCommand()
        {

        }
    }
}
