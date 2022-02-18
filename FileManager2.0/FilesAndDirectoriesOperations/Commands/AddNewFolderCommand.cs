using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndDirectoriesOperations.Commands
{
    class AddNewFolderCommand : FileManagerCommand
    {
        public AddNewFolderCommand()
        {
            Name = "AddNewFolder";
            Description = "Add new folder in the current directory";
        }
        public override void RunCommand()
        {

        }
    }
}
