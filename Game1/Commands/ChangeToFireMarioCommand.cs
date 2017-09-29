using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class ChangeToFireMarioCommand : ICommand
    {
        private Game1 gamePlay;

        public ChangeToFireMarioCommand(Game1 g)
        {
            gamePlay = g;
        }

        public void Execute()
        {
            gamePlay.Character.ChangeToFire();
            //SoundEffectFactory.Instance.CreatePowerUpTransitionSound().PlaySound();
        }
        public void Stop()
        {
            //Do nothing
        }
    }
}
