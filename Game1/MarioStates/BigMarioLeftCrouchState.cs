using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game1
{
    class BigLeftCrouchState : IMarioState
    {
        IMario container;
        ITextureAtlas character;
        public int Height { get; }
        public int Width { get; }
        public bool IsBig { get; }
        public bool IsFire { get; }

        public BigLeftCrouchState(IMario mario)
        {
            container = mario;
            character = MarioFactory.bigMarioLeftCrouchingAtlas;
            Width = character.Width;
            Height = character.Height;
            IsBig = true;
            IsFire = false;
            container.FacingRight = false;
        }


        public void ChangeToFire()
        {
            container.CurrentState = MarioFactory.Instance.CreateFireLeftCrouchingState(container);
        }

        public void ChangeToInvincible()
        {
            //Do nothing
        }

        public void ChangeToBig()
        {
            //Do nothing
        }

        public void ChangeToSmall()
        {
            container.CurrentState = MarioFactory.Instance.CreateSmallLeftStandingState(container);
        }

        public void Crouch()
        {
            //Do nothing
        }

        public void Die()
        {
            container.CurrentState = MarioFactory.Instance.CreateSmallLeftStandingState(container);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 pos)
        {
            character.Draw(spriteBatch, pos);
        }

        public void Jump()
        {
            container.CurrentState = MarioFactory.Instance.CreateBigLeftStandingState(container);
        }

        public void MoveLeft()
        {
            container.CurrentState = MarioFactory.Instance.CreateBigLeftCrouchState(container);
        }

        public void MoveRight()
        {
            container.CurrentState = MarioFactory.Instance.CreateBigRightCrouchState(container);
        }
        public void Update()
        {
            character.Update();
        }
        public void StopWalking()
        {
            //Do nothing
        }
        public void StopJumpingFalling()
        {
            container.CurrentState = MarioFactory.Instance.CreateBigLeftStandingState(container);
        }
        public IMarioState clone(IMario destination)
        {
            return MarioFactory.Instance.CreateBigLeftCrouchState(destination);
        }

        public void SetConsecutiveStreak()
        {
            throw new NotImplementedException();
        }

        public void SmashEnemy()
        {
            throw new NotImplementedException();
        }

        public int GetScore()
        {
            throw new NotImplementedException();
        }
    }
}