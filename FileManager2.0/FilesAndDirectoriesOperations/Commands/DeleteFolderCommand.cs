using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndDirectoriesOperations.Commands
{
    class DeleteFolderCommand : FileManagerCommand
    {
        public DeleteFolderCommand()
        {
            Name = "DeleteFolder";
            Description = "Delete folder";
        }
        public override void RunCommand()
        {

        }
    }
}
