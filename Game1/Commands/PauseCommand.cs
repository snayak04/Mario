using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class PauseCommand : ICommand
    {
        private Game1 gamePlay;
        private bool isPaused;

        public PauseCommand(Game1 g)
        {
            gamePlay = g;
        }
        public void Execute()
        {
            
                gamePlay.Pause();
                SoundEffectFactory.Instance.CreatePauseSound().PlaySound();
                
       
            
            
        }

        public void Stop()
        {
            //Do Nothing
        }
    }
}
