using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game1
{
    class BigLeftWalkingState : IMarioState
    {
        IMario container;
        ITextureAtlas character;
       public int Width { get; }
        public int Height { get; }
        public bool IsBig { get; }
        public bool IsFire { get; }
        public BigLeftWalkingState(IMario mario)
        {                                        
            container = mario;                  
            character = MarioFactory.bigMarioLeftWalkingAtlas;
            Width = character.Width;
            Height = character.Height;
            IsBig = true;
            IsFire = false;
        }


        public void ChangeToFire()
        {
            container.CurrentState = MarioFactory.Instance.CreateFireLeftWalkingState(container);
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
            container.CurrentState = MarioFactory.Instance.CreateSmallLeftWalkingState(container);
        }

        public void Crouch()
        {
            container.CurrentState = MarioFactory.Instance.CreateBigLeftCrouchState(container);
        }

        public void Die()
        {
            container.CurrentState = MarioFactory.Instance.CreateSmallLeftWalkingState(container);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 pos)
        {
            character.Draw(spriteBatch, pos);
        }

        public void Jump()
        {
            container.CurrentState = MarioFactory.Instance.CreateBigLeftJumpingState(container);
        }

        public void MoveLeft()
        {
            //Do nothing
        }

        public void MoveRight()
        {
            container.CurrentState = MarioFactory.Instance.CreateBigLeftStandingState(container);
        }
        public void Update()
        {
            character.Update();
        }
        public void StopWalking()
        {
            container.CurrentState = MarioFactory.Instance.CreateBigLeftStandingState(container);
        }
        public void StopJumpingFalling()
        {
            //Do nothing
        }
        public IMarioState clone(IMario destination)
        {
            return MarioFactory.Instance.CreateBigLeftWalkingState(destination);
        }
    }
}