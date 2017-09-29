using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class MoveLeftCommand : ICommand
    {
        Game1 gamePlay;

        public MoveLeftCommand(Game1 g)
        {
            gamePlay = g;
        }

        public void Execute()
        {
            if (!gamePlay.Character.ReachFlag)
            gamePlay.Character.MoveLeft();
        }

        public void Stop()
        {
            gamePlay.Character.StopWalking();
        }
    }
}
