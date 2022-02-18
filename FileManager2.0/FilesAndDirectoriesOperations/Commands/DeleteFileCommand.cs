using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndDirectoriesOperations.Commands
{
    class DeleteFileCommand : FileManagerCommand
    {
        public DeleteFileCommand()
        {
            Name = "DeleteFile";
            Description = "Delete file";
        }
        public override void RunCommand()
        {

        }
    }
}
