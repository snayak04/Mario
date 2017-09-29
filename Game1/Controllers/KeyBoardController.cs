using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace Game1
{

    class KeyBoardController : IController
    {
        Dictionary<Keys, ICommand> keyHold;
        Dictionary<Keys, ICommand> keyPress;
        private KeyboardState prevState;
        public KeyBoardController(Game1 g)
        {
            keyHold = new Dictionary<Keys, ICommand>();
            keyPress = new Dictionary<Keys, ICommand>();
            prevState = Keyboard.GetState();

            this.RegisterHoldCommand(Keys.Q, new QuitCommand(g));
            this.RegisterHoldCommand(Keys.Up, new JumpCommand(g));
            this.RegisterHoldCommand(Keys.Down, new CrouchCommand(g));
            this.RegisterHoldCommand(Keys.Left, new MoveLeftCommand(g));
            this.RegisterHoldCommand(Keys.Right, new MoveRightCommand(g));
            this.RegisterHoldCommand(Keys.X, new RunCommand(g));
            this.RegisterHoldCommand(Keys.Y, new ChangeToSmallMarioCommand(g));
            this.RegisterHoldCommand(Keys.U, new ChangeToLargeMarioCommand(g));
            this.RegisterHoldCommand(Keys.I, new ChangeToFireMarioCommand(g));
            this.RegisterHoldCommand(Keys.O, new KillMarioCommand(g));
            this.RegisterHoldCommand(Keys.Z, new JumpCommand(g));
            this.RegisterHoldCommand(Keys.S, new CrouchCommand(g));
            this.RegisterHoldCommand(Keys.A, new MoveLeftCommand(g));
            this.RegisterHoldCommand(Keys.D, new MoveRightCommand(g));

            //Single press commands
            this.RegisterPressCommand(Keys.P, new PauseCommand(g));
            this.RegisterPressCommand(Keys.R, new ResetCommand(g));
            this.RegisterPressCommand(Keys.X, new FireballCommand(g));

            Keys[] all = (Keys[])Enum.GetValues(typeof(Keys));

            foreach (Keys k in all)
            {
                if(!keyHold.ContainsKey(k))
                {
                    this.RegisterHoldCommand(k, new EmptyCommand());
                }
                if(!keyPress.ContainsKey(k))
                {
                    this.RegisterPressCommand(k, new EmptyCommand());
                }
            }
        }

        public void RegisterHoldCommand(Keys key, ICommand command)
        {
            keyHold.Add(key, command);
        }
        public void RegisterPressCommand(Keys key, ICommand command)
        {
            keyPress.Add(key, command);
        }

        public void Update()
        {
            KeyboardState newState = Keyboard.GetState();
            Keys[] previousKeys = prevState.GetPressedKeys();
            Keys[] newKeys = newState.GetPressedKeys();
            prevState = newState;

            foreach(Keys k in newKeys)
            {
                keyHold[k].Execute();

                if(!previousKeys.Contains<Keys>(k))
                {
                    keyPress[k].Execute();
                }
            }

            foreach(Keys k in previousKeys)
            {
                if(!newKeys.Contains<Keys>(k))
                {
                    keyHold[k].Stop();
                }
            }
        }
    }
}
