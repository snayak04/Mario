using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class HighScoreController : IController
    {
        private ICommand menu;
        private ICommand quit;

        private KeyboardState previousState;
        public HighScoreController(Game1 g)
        {
            menu = new MenuCommand(g);
            quit = new QuitCommand(g);
            previousState = Keyboard.GetState();
        }
        public void Update()
        {
            KeyboardState newState = Keyboard.GetState();

            Keys[] prevKeys = previousState.GetPressedKeys();
            Keys[] newKeys = newState.GetPressedKeys();

          
            if (newKeys.Contains(Keys.M) && !prevKeys.Contains(Keys.M))
            {
                menu.Execute(); // Option 1
            }
            else if (newKeys.Contains(Keys.Q) && !prevKeys.Contains(Keys.Q))
            {
                quit.Execute();
            }

            previousState = newState;
        }
    }
}
