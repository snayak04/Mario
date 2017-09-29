using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class TimeUpController : IController
    {
        private ICommand restart;
        private ICommand menu;
        private KeyboardState previousState;
        public TimeUpController(Game1 g)
        {
            restart = new ResetCommand(g);
            menu = new MenuCommand(g);
            previousState = Keyboard.GetState();
        }
        public void Update()
        {
            KeyboardState newState = Keyboard.GetState();

            Keys[] prevKeys = previousState.GetPressedKeys();
            Keys[] newKeys = newState.GetPressedKeys();

            if(newKeys.Contains(Keys.R) && !prevKeys.Contains(Keys.R))
            {
                restart.Execute();
            }else if(newKeys.Contains(Keys.M) && !prevKeys.Contains(Keys.M))
            {
                menu.Execute();
            }
            previousState = newState;
        }
    }
}
