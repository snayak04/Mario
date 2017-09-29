using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class MenuController : IController
    {
        private ICommand restart;
        private ICommand quit;
        private ICommand nightmare;

        private KeyboardState previousState;
        public MenuController(Game1 g)
        {
            restart = new ResetCommand(g);
            quit = new QuitCommand(g);
            nightmare = new NightmareCommand(g);    
            previousState = Keyboard.GetState();
        }
        public void Update()
        {
            KeyboardState newState = Keyboard.GetState();

            Keys[] prevKeys = previousState.GetPressedKeys();
            Keys[] newKeys = newState.GetPressedKeys();

            if(newKeys.Contains(Keys.D1) && !prevKeys.Contains(Keys.D1))
            {
                restart.Execute(); // Option 1
            }
            if (newKeys.Contains(Keys.D2) && !prevKeys.Contains(Keys.D2))
            {
                nightmare.Execute(); // Option 1
            }
            else if (newKeys.Contains(Keys.Q) && !prevKeys.Contains(Keys.Q))
            {
                quit.Execute();
            }

            previousState = newState;
        }
    }
}
