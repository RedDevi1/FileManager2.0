using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndDirectoriesOperations.Commands
{
    class CopyFolderCommand : FileManagerCommand
    {
        public CopyFolderCommand()
        {
            Name = "CopyFolder";
            Description = "Copy folder";
        }
        public override void RunCommand()
        {

        }
    }
}
