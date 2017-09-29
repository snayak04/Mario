using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class EmptyCommand : ICommand
    {
        

        public EmptyCommand()
        {
        }

        public void Execute()
        {
            
        }

        public void Stop()
        {
            //Do nothing
        }
    }
}
