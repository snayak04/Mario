using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class KillMarioCommand : ICommand
    {
        Game1 gamePlay;

        public KillMarioCommand(Game1 g)
        {
            gamePlay = g;
        }

        public void Execute()
        {
            gamePlay.Character.Die();
        }
        public void Stop()
        {
            //Do nothing
        }
    }
}
