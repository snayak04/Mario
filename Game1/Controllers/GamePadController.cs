using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;


namespace Game1
{
    class GamePadController : IController
    {
        public enum Action { QUIT, MOVEUP, MOVEDOWN, MOVELEFT, MOVERIGHT,CHANGETOFIRE, CHANGETOBIG, CHANGETOSMALL, DIE , SHOOT};

        private Dictionary<Action, ICommand> mappings;
        private GamePadState prevState;

        public GamePadController(Game1 g)
        {
            mappings = new Dictionary<Action, ICommand>();
            prevState = GamePad.GetState(PlayerIndex.One);


            //Set the Quit command
            this.RegisterCommand(Action.QUIT, new QuitCommand(g));

            //Set the movement commands
            this.RegisterCommand(Action.MOVEDOWN, new CrouchCommand(g));
            this.RegisterCommand(Action.MOVEUP, new JumpCommand(g));
            this.RegisterCommand(Action.MOVERIGHT, new MoveRightCommand(g));
            this.RegisterCommand(Action.MOVELEFT, new MoveLeftCommand(g));

            //Set the state change commands
            this.RegisterCommand(Action.SHOOT, new FireballCommand(g));
            this.RegisterCommand(Action.CHANGETOSMALL, new ChangeToSmallMarioCommand(g));
            this.RegisterCommand(Action.CHANGETOFIRE, new ChangeToFireMarioCommand(g));
            this.RegisterCommand(Action.CHANGETOBIG, new ChangeToLargeMarioCommand(g));
        }

        public void RegisterCommand(Action act, ICommand cmd)
        {
            mappings.Add(act, cmd);
        }
        public void Update()
        {
            GamePadState gState = GamePad.GetState(PlayerIndex.One);
            float leftThumbX = gState.ThumbSticks.Left.X;
            float leftThumbY = gState.ThumbSticks.Left.Y;
            float prevLeftThumbX = prevState.ThumbSticks.Left.X;
            float prevLeftThumbY = prevState.ThumbSticks.Left.Y;

            double radians = Math.Atan2(leftThumbY, leftThumbX);

            //Ability to quit
            if(gState.Buttons.Start == ButtonState.Pressed)
            {
                mappings[Action.QUIT].Execute();
            }

            if(gState.Buttons.A == ButtonState.Pressed)
            {
                mappings[Action.MOVEUP].Execute();
            }

            if(gState.Buttons.X == ButtonState.Pressed)
            {
                mappings[Action.CHANGETOSMALL].Execute();
            }

            if(gState.Buttons.Y == ButtonState.Pressed)
            {
                mappings[Action.CHANGETOBIG].Execute();
            }

            if(gState.Buttons.B == ButtonState.Pressed)
            {
                mappings[Action.SHOOT].Execute();
            }

            //check to make sure the joystick is being moved
            if(leftThumbY != prevLeftThumbY || leftThumbX != prevLeftThumbX)
            {
                mappings[Action.MOVEUP].Stop();
                mappings[Action.MOVEDOWN].Stop();
                mappings[Action.MOVERIGHT].Stop();
                mappings[Action.MOVELEFT].Stop();
            }
            if(leftThumbY !=0 || leftThumbX != 0)
            {
                //Go through the math and find which direction the joystick is being pushed. Have a 30 degree
                //clearance on either side of the X and Y axes before moving diagonally
                if(radians < -(5*Math.PI)/6)
                {
                    mappings[Action.MOVELEFT].Execute();
                }
                else if (radians < -(2* Math.PI)/3)
                {
                    mappings[Action.MOVELEFT].Execute();
                    mappings[Action.MOVEDOWN].Execute();
                }
                else if (radians < -(Math.PI/3))
                {
                    mappings[Action.MOVEDOWN].Execute();
                }
                else if (radians < -(Math.PI/6))
                {
                    mappings[Action.MOVEDOWN].Execute();
                    mappings[Action.MOVERIGHT].Execute();
                }
                
                else if (radians < Math.PI / 6)
                {
                    mappings[Action.MOVERIGHT].Execute();
                }
                else if (radians < Math.PI / 3)
                {
                    mappings[Action.MOVERIGHT].Execute();
                    mappings[Action.MOVEUP].Execute();
                }
                else if (radians < (2 * Math.PI) / 3)
                {
                    mappings[Action.MOVEUP].Execute();
                }
                else if (radians < (5 * Math.PI) / 6)
                {
                    mappings[Action.MOVEUP].Execute();
                    mappings[Action.MOVELEFT].Execute();
                }
                else if (radians < (7 * Math.PI) / 6)
                {
                    mappings[Action.MOVELEFT].Execute();
                }
                else if (radians < (4 * Math.PI) / 3)
                {
                    mappings[Action.MOVELEFT].Execute();
                    mappings[Action.MOVEDOWN].Execute();
                }
                else if (radians < (5 * Math.PI) / 3)
                {
                    mappings[Action.MOVEDOWN].Execute();
                }
                else if (radians < (11 * Math.PI) / 6)
                {
                    mappings[Action.MOVEDOWN].Execute();
                    mappings[Action.MOVERIGHT].Execute();
                }
                else if (radians > (11 * Math.PI) / 6)
                {
                    mappings[Action.MOVERIGHT].Execute();
                }
            }

            prevState = gState;
        }
    }
}
