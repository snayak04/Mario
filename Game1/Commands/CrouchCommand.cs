using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class CrouchCommand : ICommand
    {
        Game1 gamePlay;

        public CrouchCommand(Game1 g)
        {
            gamePlay = g;
        }

        public void Execute()
        {
            gamePlay.Character.Movement.IsCrouching = true;
                gamePlay.Character.Crouch();

        }

        public void Stop()
        {
            gamePlay.Character.Movement.IsCrouching = false;
            gamePlay.Character.StopCrouching();
        }
    }
}
