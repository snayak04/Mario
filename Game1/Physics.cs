using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class Physics
    {
        public static float Gravity = 5;
        public Vector2 Velocity;
        public bool BoundBelow;
        private int maxJump = 45;
        private int currJump;
        private int walkSpeed = 2;
        private int runSpeed = 4;
        private int currentSpeed;
        public bool jumping;
        public bool Falling;
        public bool IsCrouching;
        public bool ReachFlag;

        public Physics()
        {
            Velocity = new Vector2(0, 0);
            BoundBelow = true;
            currJump = 0;
            jumping = false;
            Falling = false;
            BoundBelow = true;
            currentSpeed = walkSpeed;
            IsCrouching = false;
            ReachFlag = false;

        }

        public void Run()
        {
            currentSpeed = runSpeed;
        }

        public void Update()
        {
            if (!ReachFlag)
            {
                if (BoundBelow)
                {
                    Falling = false;

                    Velocity.Y = 0;
                }
                else if (Velocity.Y != Gravity && Falling)
                {
                    Velocity.Y = Gravity;
                }
                else if (!Falling && !jumping)
                {
                    Velocity.Y = 0;
                }
            }
            else
            {
                //Velocity.X = 1;
            }
        }

        public void MoveLeft()
        {
            Velocity.X = -currentSpeed;
        }

        public void StopWalking()
        {
            Velocity.X = 0;
        }

        public void MoveRight()
        {
            Velocity.X = currentSpeed;
        }

        public void StopAllMovement()
        {
            Velocity = new Vector2(0, 0);
        }

        public void StopJumping()
        {
            jumping = false;
            Falling = true;
        }

        public void StopRunning()
        {
            currentSpeed = walkSpeed;
        }

        public void Jump()
        {
            if(!jumping && !Falling)
            {
                BoundBelow = false;
                jumping = true;
                Velocity.Y = -5;
                SoundEffectFactory.Instance.CreateJumpSuperSound().PlaySound();
            }
            if(currJump < maxJump && !Falling)
            {
                currJump++;
            } else
            {
                Falling = true;
            }
            
        }

        public void Fall()
        {
            if(!jumping)
            {
                Falling = true;
                BoundBelow = false;
            }
        }

        public void Land()
        {
            jumping = false;
            Falling = false;
            currJump = 0;
            BoundBelow = true;
            
        }

        public Physics clone()
        { 
            Physics newP = new Physics();
            newP.Velocity = new Vector2(this.Velocity.X, this.Velocity.Y);
            newP.BoundBelow = this.BoundBelow;
            newP.currJump = this.currJump;
            newP.jumping = this.jumping;
            newP.Falling = this.Falling;

            return newP;
        }

        public void Flag()
        {
            ReachFlag = true;
            Velocity = new Vector2(0, 5);
        }

        public void FlagLand()
        {
            Velocity = new Vector2(0, 0);
        }
    }
}
