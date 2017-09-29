using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class TransitionMario : IMario
    {
        private static bool isBouncing;
        int downCount;
        public bool ReachFlag { get; set; }
        public int JumpCounter { get; set; }
        public bool FacingRight { get; set; }     //to be removed
        public IMarioState CurrentState
        {
            get
            {
                return current.CurrentState;
            }
            set
            {
                current.CurrentState = value;
            }
        }
        public Rectangle Position
        {
            get
            {
                return next.Position;
            }
            set
            {
                next.Position = value;
                previous.Position = value;
            }
        }
        public Physics Movement
        {
            get
            {
                return next.Movement;
            }
            set
            {
                next.Movement = value;
                previous.Movement = value;
            }
        }
        public int GetCoin
        {
            get
            {
                return next.GetCoin;
            }
            set
            {
                next.GetCoin = value;
            }
        }
        public bool Invincible
        {
            get
            {
                return false;
            }
            set
            {
                //Do nothing
            }
        }

        public int LifeCount
        {
            get
            {
                return next.LifeCount;
            }
            set
            {
                next.LifeCount = value;
            }
        }

        public bool consecutiveCrash
        {
            get
            {
                return current.consecutiveCrash;
            }
            set
            {
                current.consecutiveCrash = value;
            }
        }
        private IMario previous;
        private IMario next;
        private bool switchStateShown;
        private IMario current;
        private Game1 gamePlay;

        private int switchDelay = 10;
        private int currDelay;

        private int totalBlinks = 10;
        private int currBlink = 0;

        public TransitionMario(IMario src, IMario dest, Game1 g)
        {
            previous = src;
            next = dest;
            current = dest;
            gamePlay = g;
            switchStateShown = false;
        }
        public void BounceX(int width)
        {
        }

        public void BounceY(int height)
        {
        }

        public void StopCrouching()
        {
            //Do nothing
        }

        public void ChangeToFire()
        {
            //Do nothing
        }

        public void ChangeToInvincible()
        {
            //Do nothing
        }

        public void ChangeToLarge()
        {
            //Do nothing
        }

        public void ChangeToSmall()
        {
            //Do nothing
        }

        public void CoinCount()
        {
        }

        public void Crouch()
        {
        }

        public void Die()
        {
            //Do nothing
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            current.Draw(spriteBatch);
        }

        public void Jump()
        {
        }

        public void MoveLeft()
        {
        }

        public void MoveRight()
        {
        }

        public void PlusLife()
        {
            //Do nothing
        }

        public void StopJumping()
        {
            next.StopJumping();
            previous.StopJumping();
        }

        public void StopWalking()
        {
            previous.StopWalking();
            next.StopWalking();
        }

        public void Land()
        {
            //Do nothing
        }
        public void Update()
        {
            currDelay++;
            
            if (currDelay == switchDelay)
            {
                switchStateShown = true;
                currDelay = 0;
                currBlink++;
            }

            if(switchStateShown)
            {
                if(current == next)
                {
                    current = previous;
                }
                else
                {
                    current = next;
                }
                switchStateShown = false;
            }

            if(currBlink == totalBlinks)
            {
                
                gamePlay.Character = next;
            }
        }

        public void Shoot()
        {
            //Do nothing
        }

        public IMario clone()
        {
            return this;
        }

        public void Bounce()
        {
            isBouncing = true;
            downCount = 0;
        }

        public void SetConsecutiveStreak()
        {
//          do nothing
                    }

        public void SmashEnemy()
        {
            //do nothing     
        }

        public int GetScore()
        {
            return previous.GetScore();
        }

        public void BreakStreak()
        {
            //do nothing        
        }

        public void ProjectileSmash()
        {
            // do nothing
        }
        public bool isInRange(Vector2 position)
        {
            return current.isInRange(position);
        }

        public void Flag()
        {
            //throw new NotImplementedException();
        }

        public void ChangeLevel(Vector2 startPos)
        {
            current.ChangeLevel(startPos);
        }

        public void FlagLand()
        {
            //throw new NotImplementedException();
        }
    }
}
