using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game1
{
    class BigRightCrouchState : IMarioState
    {
        IMario container;
        ITextureAtlas character;
        public int Height { get; }
        public int Width { get; }
        public bool IsBig { get; }
        public bool IsFire { get; }

        public BigRightCrouchState(IMario mario)
        {
            container = mario;
            character = MarioFactory.bigMarioRightCrouchingAtlas;
            Height = character.Height;
            Width = character.Width;
            IsBig = true;
            IsFire = false;
        }

        public void ChangeToFire()
        {
            container.CurrentState = MarioFactory.Instance.CreateFireRightCrouchingState(container);
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
            container.CurrentState = MarioFactory.Instance.CreateSmallRightStandingState(container);
        }

        public void Crouch()
        {
            //Do nothing
        }

        public void Die()
        {
            container.CurrentState = MarioFactory.Instance.CreateSmallRightStandingState(container);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 pos)
        {
            character.Draw(spriteBatch, pos);
        }

        public void Jump()
        {
            container.CurrentState = MarioFactory.Instance.CreateBigRightStandingState(container);

        }

        public void MoveLeft()
        {
            container.CurrentState = MarioFactory.Instance.CreateBigLeftCrouchState(container);
        }

        public void MoveRight()
        {
            container.CurrentState = MarioFactory.Instance.CreateBigRightCrouchState(container);        }

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
            container.CurrentState = MarioFactory.Instance.CreateBigRightStandingState(container);
        }
        public IMarioState clone(IMario destination)
        {
            return MarioFactory.Instance.CreateBigRightCrouchState(destination);
        }
    }
}
