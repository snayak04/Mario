using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class HurtMario : IMario
    {
        public bool ReachFlag { get; set; }
        private IMario hurtMario;
        private Game1 gamePlay;
        private const int DURATION = 120;
        private int timer;
        private static bool isBouncing;
        int downCount;
        public Rectangle Position
        {
            get
            {
                return hurtMario.Position;
            }
            set
            {
                hurtMario.Position = value;
            }
        }
        public int JumpCounter
        {
            get
            {
                return hurtMario.JumpCounter;
            }
            set
            {
                hurtMario.JumpCounter = value;
            }
        }

        public Physics Movement
        {
            get
            {
                return hurtMario.Movement;
            }
            set
            {
                hurtMario.Movement = value;
            }
        }

        public IMarioState CurrentState
        {
            get
            {
                return hurtMario.CurrentState;
            }
            set
            {
                hurtMario.CurrentState = value;
            }
        }
        public int GetCoin
        {
            get
            {
                return hurtMario.GetCoin;
            }
            set
            {
                hurtMario.GetCoin = value;
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
        public bool FacingRight
        {
            get
            {
                return hurtMario.FacingRight;
            }
            set
            {
                hurtMario.FacingRight = value;
            }
        }

        public int LifeCount
        {
            get
            {
                return hurtMario.LifeCount;
            }
            set
            {
                hurtMario.LifeCount = value;
            }
        }

        public bool consecutiveCrash
        {
            get
            {
                return hurtMario.consecutiveCrash;
            }
            set
            {
                hurtMario.consecutiveCrash = value;
            }
        }
        public HurtMario(IMario dying, Game1 g)
        {
            hurtMario = dying;
            gamePlay = g;
            timer = 0;
        }

        public void StopCrouching()
        {
            hurtMario.StopCrouching();
        }

        public IMario clone()
        {
            return new HurtMario(hurtMario.clone(), gamePlay);
        }

        public void Update()
        {
            hurtMario.Update();
            timer++;
            
            if (timer == DURATION)
            {
                gamePlay.Character = hurtMario;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            hurtMario.Draw(spriteBatch);
        }

        public void Jump()
        {
            hurtMario.Jump();
        }

        public void Crouch()
        {
            hurtMario.Crouch();
        }

        public void MoveLeft()
        {
            hurtMario.MoveLeft();
        }

        public void MoveRight()
        {
            hurtMario.MoveRight();
        }

        public void ChangeToFire()
        {
            hurtMario.ChangeToFire();
        }

        public void ChangeToLarge()
        {
            hurtMario.ChangeToLarge();
        }

        public void ChangeToSmall()
        {
            hurtMario.ChangeToSmall();
        }

        public void ChangeToInvincible()
        {
            hurtMario.ChangeToInvincible();
        }

        public void StopWalking()
        {
            hurtMario.StopWalking();
        }

        public void StopJumping()
        {
            hurtMario.StopJumping();
        }

        public void Die()
        {
            //Do nothing
        }

        public void PlusLife()
        {
            hurtMario.PlusLife();
        }

        public void Land()
        {
            hurtMario.Land();
        }
        public void CoinCount()
        {
            hurtMario.CoinCount();
        }

        public void BounceX(int width)
        {
            hurtMario.BounceX(width);
        }

        public void BounceY(int height)
        {
            hurtMario.BounceY(height);
        }

        public void Shoot()
        {
            hurtMario.Shoot();
        }

        public void Bounce()
        {
            isBouncing = true;
            downCount = 0;        }

       
        public void SmashEnemy()
        {
            hurtMario.SmashEnemy();
        }

        public int GetScore()
        {
            return hurtMario.GetScore();     }

        public void BreakStreak()
        {
            hurtMario.BreakStreak();        }

        public void ProjectileSmash()
        {
            hurtMario.ProjectileSmash();
        }

        public bool isInRange(Vector2 position)
        {
            return hurtMario.isInRange(position);

        }

        public void Flag()
        {
            //throw new NotImplementedException();
        }

        public void ChangeLevel(Vector2 startPos)
        {
            hurtMario.ChangeLevel(startPos);
        }

        public void FlagLand()
        {
            //throw new NotImplementedException();
        }
    }
}
