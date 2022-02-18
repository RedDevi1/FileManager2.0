using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndDirectoriesOperations.Commands
{
    class AddNewFileCommand : FileManagerCommand
    {
        public AddNewFileCommand ()
        {
            Name = "AddNewFile";
            Description = "Add new file in the current directory";
        }
        public override void RunCommand()
        {

        }
    }
}
