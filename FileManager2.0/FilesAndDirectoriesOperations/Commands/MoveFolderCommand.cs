using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndDirectoriesOperations.Commands
{
    class MoveFolderCommand : FileManagerCommand
    {
        public MoveFolderCommand()
        {
            Name = "MoveFolder";
            Description = "Move folder from the current directory to another";
        }
        public override void RunCommand()
        {

        }
    }
}
