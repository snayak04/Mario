using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace Game1
{
    public class Mario : IMario
    {
        public bool ReachFlag { get; set; }
        public  IMarioState CurrentState { get; set; }
        private static bool isBouncing;
        int downCount;
        public int JumpCounter { get; set; }
        public Rectangle Position { get; set; }
        public bool FacingRight { get; set; }
        public bool Invincible { get; set; }
        public Physics Movement { get; set; }
        public int GetCoin { get; set; }
        public IProjectile fireball;
        //Bottom left corner
        public Vector2 pos;
        public Vector2 shootPos;
        public bool shotRight;
        private int coinCount;
        private int score;
        public Boolean consecutiveCrash { get; set; }
        private Game1 gamePlay;

        public int LifeCount { get; set; }
        
        public Mario(Vector2 startPos, Game1 g) 
        {
            ReachFlag = false;
            CurrentState = MarioFactory.Instance.CreateSmallRightStandingState(this);
            pos = startPos;
            pos.Y += CurrentState.Height;
            Invincible = false;
            Movement = new Physics();
            coinCount = 0;
            LifeCount = 3;
            Position = new Rectangle((int) startPos.X, (int)startPos.Y-CurrentState.Height, CurrentState.Width, CurrentState.Height);
            gamePlay = g;
            FacingRight = true;
            shotRight = false;
            isBouncing = false;
            consecutiveCrash = false;
            score = 0;
            JumpCounter = 0;
        }
        public void ChangeLevel(Vector2 startPos)
        {
            if (!(CurrentState is SmallMarioDeadState))
            {
                FacingRight = true;
                ReachFlag = false;
                pos = startPos;
                pos.Y += CurrentState.Height;
                Position = new Rectangle((int)startPos.X, (int)startPos.Y - CurrentState.Height, CurrentState.Width, CurrentState.Height);
                Movement = new Physics();
                isBouncing = false;
                consecutiveCrash = false;
                consecutiveCrash = false;
            }
            else
            {
                CurrentState = MarioFactory.Instance.CreateSmallRightStandingState(this);
                FacingRight = true;
                ReachFlag = false;
                pos = startPos;
                pos.Y += CurrentState.Height;
                Position = new Rectangle((int)startPos.X, (int)startPos.Y - CurrentState.Height, CurrentState.Width, CurrentState.Height);
                Movement = new Physics();
                isBouncing = false;
                consecutiveCrash = false;
                consecutiveCrash = false;
            }
        }
        public void Update()
        {
            if (isBouncing)
            {
                if (downCount < 15)
                {
                    pos.Y -=3;
                    pos.X += Movement.Velocity.X;
                    downCount++;
                }
                else
                {
                    isBouncing = false;
                }
            }
            else
            {
                pos.X += Movement.Velocity.X;
                pos.Y += Movement.Velocity.Y;
            }
            this.UpdatePosition();
            Movement.Update();
            CurrentState.Update();
        }

        private void UpdatePosition()
        {
            Position = new Rectangle((int)pos.X, (int)pos.Y - CurrentState.Height, CurrentState.Width, CurrentState.Height);
        }
        public void Bounce()
        {
            isBouncing = true;
            downCount = 0;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            CurrentState.Draw(spriteBatch, pos);
        }

        public void Jump()
        {
            Movement.Jump();
            CurrentState.Jump();
            JumpCounter++;
        }

        public void Flag()
        {
            Movement.Flag();
            ReachFlag = true;
            //SoundEffectFactory.Instance.CreateFlagpoleSound().PlaySound();
        }

        public void Crouch()
        {
            CurrentState.Crouch();
        }

        public void MoveLeft()
        {
            Movement.MoveLeft();
            CurrentState.MoveLeft();
            FacingRight = false;
        }

        public void MoveRight()
        {
            Movement.MoveRight();
            CurrentState.MoveRight();
            FacingRight = true;
        }

        public void ChangeToFire()
        {
            IMario nextGuy = this.clone();
            nextGuy.CurrentState.ChangeToFire();

            gamePlay.Character = new TransitionMario(this, nextGuy, gamePlay);
            SoundEffectFactory.Instance.CreatePowerUpTransitionSound().PlaySound();
        }

        public void ChangeToLarge()
        {
            IMario nextGuy = this.clone();
            nextGuy.CurrentState.ChangeToBig();

            gamePlay.Character = new TransitionMario(this, nextGuy, gamePlay);
            SoundEffectFactory.Instance.CreatePowerUpTransitionSound().PlaySound();
        }

        public void ChangeToSmall()
        {
            IMario nextGuy = this.clone();
            nextGuy.CurrentState.ChangeToSmall();

            gamePlay.Character = new TransitionMario(this, nextGuy, gamePlay);
            SoundEffectFactory.Instance.CreatePipeDownSound().PlaySound();
        }

        public void ChangeToInvincible()
        {
            MediaPlayer.Pause();
            SoundEffectFactory.Instance.CreateInvicibleSound();
            gamePlay.Character = new StarMario(this, gamePlay);
        }

        public void Die()
        {
            if (!gamePlay.Character.CurrentState.IsBig)
            {
                SoundEffectFactory.Instance.CreateNightmareMarioDyingSound().PlaySound();
            }
            if (gamePlay.Character.CurrentState.IsBig)
            {
                SoundEffectFactory.Instance.CreatePipeDownSound().PlaySound();
            }
            CurrentState.Die();

            if(!(CurrentState is SmallMarioDeadState))
            {
                gamePlay.Character = new HurtMario(this, gamePlay);
            }
            else
            {
                --LifeCount;
                Movement.Velocity.X = 0;
                Movement.Velocity.Y = 0;
                //gamePlay.CurrentState = new MarioDeadState(gamePlay, gamePlay.CurrentState);
                gamePlay.CurrentState.Dying();
            }
        }
        public void StopWalking()
        {
            Movement.StopWalking();
            CurrentState.StopWalking();
        }

        public void StopJumping()
        {
            Movement.StopJumping();
            JumpCounter = 0;
        }

        public void StopCrouching()
        {
            CurrentState.StopJumpingFalling();
        }

        public void Land()
        {
            Movement.Land();
            CurrentState.StopJumpingFalling();
        }

        public void PlusLife()
        {
            LifeCount++;
        }

        public void CoinCount()
        {
            GetCoin++; 
            this.ProjectileSmash();
        }
        int consecutive = 100;
        public void SmashEnemy()
        {
            if (consecutiveCrash)
            {
                score += consecutive;
                consecutive *= 2;
            }
            else
            {
                score += consecutive;
            }
        }
        public void ProjectileSmash()
        {
            score += 100;
        }
       public void BreakStreak()
        {
            consecutive = 100;
            consecutiveCrash = false;
        }
        public int GetScore()
        {
            return score;
        }
        public void BounceX(int width)
        {
            pos.X += width;
            this.UpdatePosition();
        }
        public void BounceY(int height)
        {
            pos.Y += height;
            this.UpdatePosition();
        }
        public void Shoot()
        {
            if (this.CurrentState.IsFire || this.Invincible && this.CurrentState.IsFire)
            {
                if (this.FacingRight)
                {
                    shotRight = true; //compute the vector pos so fireball appears on the right side of Mario about shoulder level
                    shootPos = new Vector2(pos.X + this.CurrentState.Width, pos.Y - (float)(0.75 * this.CurrentState.Height));
                }
                else
                {
                    shotRight = false; //else compute the vector pos for a FB shot from the left side of Mario about shoulder level
                    shootPos = new Vector2(pos.X, pos.Y - (float)(0.75 * this.CurrentState.Height));
                }
                fireball = ProjectileFactory.Instance.CreateFireball(shootPos, shotRight);
                ((PlayGameState)gamePlay.CurrentState).projectiles.Add(fireball);
                SoundEffectFactory.Instance.CreateFireballShotSound().PlaySound();
            }
            else
            {
                Movement.Run();
            }
        }
        public Boolean isInRange(Vector2 position)
        {
            int initialWidth = 550, width = 800;
            Rectangle camPos = this.Position;
            if (camPos.X > 450)
                return position.X <= camPos.X + initialWidth;
            else
                return (position.X <= camPos.X + width);
        }
        public IMario clone()
        {
            Vector2 newMPos = new Vector2(this.Position.Location.X, this.Position.Location.Y);
            Mario newM = new Mario(newMPos, gamePlay);
            newM.pos = this.pos;
            newM.CurrentState = this.CurrentState.clone(newM);
            newM.FacingRight = this.FacingRight;
            newM.Invincible = this.Invincible;
            newM.Movement = this.Movement.clone();
            newM.GetCoin = this.GetCoin;
            newM.shootPos = new Vector2(this.shootPos.X, this.shootPos.Y);
            newM.shotRight = this.shotRight;
            newM.LifeCount = this.LifeCount;
            newM.coinCount = this.coinCount;
            newM.score = this.GetScore();
            return newM;
        }

        public void FlagLand()
        {
            if (ReachFlag)
            {
                Movement.FlagLand();
            }
            //Movement.MoveRight();
            //throw new NotImplementedException();
        }
    }
}
