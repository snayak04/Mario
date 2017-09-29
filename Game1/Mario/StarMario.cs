using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class StarMario : IMario
    {
        public bool ReachFlag { get; set; }
        public bool FacingRight { get; set; }
        public bool Invincible { get; set; }
        private static bool isBouncing;
        int downCount;

        private Game1 gamePlay;
        IMario decoratedMario;
        int timer;

        public StarMario(IMario m, Game1 g)
        {
            decoratedMario = m;
            timer = 1200;
            Invincible = true;
            gamePlay = g;
        }
        public IMarioState CurrentState
        {
            get
            {
                return decoratedMario.CurrentState;
            }
            set
            {
                decoratedMario.CurrentState = value;
            }
        }
        public int JumpCounter
        {
            get
            {
                return decoratedMario.JumpCounter;
            }
            set
            {
                decoratedMario.JumpCounter = value;
            }
        }
        public Rectangle Position
        {
            get
            {
                return decoratedMario.Position;
            }
            set
            {
                decoratedMario.Position = value;
            }
        }

        public Physics Movement
        {
            get
            {
                return decoratedMario.Movement;
            }
            set
            {
                decoratedMario.Movement = value;
            }
        }

        public int GetCoin
        {
            get
            {
                return decoratedMario.GetCoin;
            }
            set
            {
                decoratedMario.GetCoin = value;
            }
        }

        public bool consecutiveCrash { 
            get
            {
                return decoratedMario.consecutiveCrash;
            }
            set
            {
                decoratedMario.consecutiveCrash = value;
            }
        }

        public int LifeCount
        {
            get
            {
                return decoratedMario.LifeCount;
            }
            set
            {
                decoratedMario.LifeCount = value;
            }
        }

        

        public void BounceX(int width)
        {
            decoratedMario.BounceX(width);
        }

        public void BounceY(int height)
        {
            decoratedMario.BounceY(height);
        }

        public void ChangeToFire()
        {
            decoratedMario.ChangeToFire();
        }

        public void ChangeToInvincible()
        {
            //Do nothing
        }

        public void ChangeToLarge()
        {
            decoratedMario.ChangeToLarge();
        }

        public void ChangeToSmall()
        {
            decoratedMario.ChangeToSmall();
        }

        public void CoinCount()
        {
           decoratedMario.CoinCount();
        }

        public void Crouch()
        {
            decoratedMario.Crouch();
        }

        public void Die()
        {
            //Do nothing - Invincible
        }

        public void Jump()
        {
            decoratedMario.Jump();
        }

        public void MoveLeft()
        {
            decoratedMario.MoveLeft();
        }

        public void MoveRight()
        {
            decoratedMario.MoveRight();
        }

        public void PlusLife()
        {
            decoratedMario.PlusLife();
        }

        public void StopJumping()
        {
            decoratedMario.StopJumping();
        }

        public void StopWalking()
        {
            decoratedMario.StopWalking();
        }

        public void Shoot()
        {
            decoratedMario.Shoot();
        }

        public void Land()
        {
            decoratedMario.Land();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            decoratedMario.Draw(spriteBatch);
        }

        public void StopCrouching()
        {
            decoratedMario.StopCrouching();
        }

        public void Update()
        {
            timer--;
            decoratedMario.Update();
            
            if (timer == 0)
            {
                gamePlay.Character = decoratedMario;
                MediaPlayer.Resume();
            }
        }

        public IMario clone()
        {
            StarMario newM = new StarMario(decoratedMario.clone(), gamePlay);
            newM.timer = this.timer;
            return newM;
        }

        public void Bounce()
        {
            isBouncing = true;
            downCount = 0; 
        }

       

        public void SmashEnemy()
        {
            decoratedMario.SmashEnemy();        }

        public int GetScore()
        {
            return decoratedMario.GetScore();        }

        public void BreakStreak()
        {
            decoratedMario.BreakStreak();        }

        public void ProjectileSmash()
        {
            decoratedMario.ProjectileSmash();
        }

        public bool isInRange(Vector2 position)
        {
            return decoratedMario.isInRange(position);
        }

        public void Flag()
        {
            //throw new NotImplementedException();
        }

        public void ChangeLevel(Vector2 startPos)
        {
            decoratedMario.ChangeLevel(startPos);
        }

        public void FlagLand()
        {
            //throw new NotImplementedException();
        }
    }
}
