using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndDirectoriesOperations.Commands
{
    class MoveFileCommand : FileManagerCommand
    {
        public MoveFileCommand()
        {
            Name = "MoveFile";
            Description = "Move file from the current directory to another";
        }
        public override void RunCommand()
        {

        }
    }
}
