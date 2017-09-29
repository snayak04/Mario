using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class MenuCommand : ICommand
    {
        Game1 gamePlay;

        public MenuCommand(Game1 g)
        {
            gamePlay = g;
        }

        public void Execute()
        {
            gamePlay.Menu();
        }

        public void Stop()
        {
            //Do nothing
        }
    }
}
