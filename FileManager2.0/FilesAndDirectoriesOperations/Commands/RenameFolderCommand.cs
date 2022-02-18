using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndDirectoriesOperations.Commands
{
    class RenameFolderCommand : FileManagerCommand
    {
        public RenameFolderCommand()
        {
            Name = "RenameFolder";
            Description = "Rename folder";
        }
        public override void RunCommand()
        {

        }
    }
}
