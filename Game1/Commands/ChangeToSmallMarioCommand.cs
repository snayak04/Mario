using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class ChangeToSmallMarioCommand : ICommand
    {
        Game1 gamePlay;

        public ChangeToSmallMarioCommand(Game1 g)
        {
            gamePlay = g;
        }

        public void Execute()
        {
            gamePlay.Character.ChangeToSmall();
            //SoundEffectFactory.Instance.CreatePowerUpTransitionSound().PlaySound();  Should be Mario taking damage sound.
        }

        public void Stop()
        {
            //Do nothing
        }
    }
}
