using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class PauseController : IController
    {
        private ICommand unpause;
        private KeyboardState previousState;
        public PauseController(Game1 g)
        {
            unpause = new PauseCommand(g);
            previousState = Keyboard.GetState();
        }
        public void Update()
        {
            KeyboardState newState = Keyboard.GetState();

            Keys[] prevKeys = previousState.GetPressedKeys();
            Keys[] newKeys = newState.GetPressedKeys();

            if(newKeys.Contains(Keys.P) && !prevKeys.Contains(Keys.P))
            {
                unpause.Execute();
            }

            previousState = newState;
        }
    }
}
