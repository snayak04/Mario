using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class NightmareCommand : ICommand
    {
        Game1 gamePlay;

        public NightmareCommand(Game1 g)
        {
            gamePlay = g;
        }

        public void Execute()
        {
            gamePlay.Nightmare();
        }

        public void Stop()
        {
            //Do nothing
        }
    }
}
