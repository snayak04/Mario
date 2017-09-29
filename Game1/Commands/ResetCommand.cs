using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class ResetCommand : ICommand
    {
        Game1 gamePlay;

        public ResetCommand(Game1 g)
        {
            gamePlay = g;
        }

        public void Execute()
        {
            gamePlay.Reset();
        }

        public void Stop()
        {
            //Do nothing
        }
    }
}
