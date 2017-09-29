using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class ChangeToLargeMarioCommand : ICommand
    {
        private Game1 gamePlay;

        public ChangeToLargeMarioCommand(Game1 g)
        {
            gamePlay = g;
        }

        public void Execute()
        {
            gamePlay.Character.ChangeToLarge();
            //SoundEffectFactory.Instance.CreatePowerUpTransitionSound().PlaySound();
        }
        public void Stop()
        {
            //Do nothing
        }
    }
}
