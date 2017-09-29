using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game1
{
    class BigMarioLeftStandingState : IMarioState
    {
        IMario container;
        ITextureAtlas character;
        public int Height { get; }
        public int Width { get; }
        public bool IsBig { get; }
        public bool IsFire { get; }

        public BigMarioLeftStandingState(IMario mario) 
        {
            container = mario;
            character = MarioFactory.bigMarioLeftStandingAtlas;
            Height = character.Height;
            Width = character.Width;
            IsBig = true;
            IsFire = false;
        }

        public void ChangeToFire()
        {
            container.CurrentState = MarioFactory.Instance.CreateFireLeftStandingState(container);
            container.FacingRight = false;
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
            container.CurrentState = MarioFactory.Instance.CreateBigLeftCrouchState(container);
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
            container.CurrentState =   MarioFactory.Instance.CreateBigLeftJumpingState(container);
        }

        public void MoveLeft()
        {
            container.CurrentState = MarioFactory.Instance.CreateBigLeftWalkingState(container);
        }

        public void MoveRight()
        {
           container.CurrentState =  MarioFactory.Instance.CreateBigRightStandingState(container);
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
            //Do nothing
        }
        public IMarioState clone(IMario destination)
        {
            return MarioFactory.Instance.CreateBigLeftStandingState(destination);
        }
    }
}
