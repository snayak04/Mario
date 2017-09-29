using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game1
{
    class BigRightStandingState : IMarioState
    {
        IMario container;
        ITextureAtlas character;
        public int Width { get; }
        public int Height { get; }
        public bool IsBig { get; }
        public bool IsFire { get; }

        public BigRightStandingState(IMario mario)
        {
            container = mario;
            character = MarioFactory.bigMarioRightStandingAtlas;
            Height = character.Height;
            Width = character.Width;
            IsBig = true;
            IsFire = false;
        }

        public void ChangeToFire()
        {
            container.CurrentState = MarioFactory.Instance.CreateFireRightStandingState(container);
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
            container.CurrentState = MarioFactory.Instance.CreateBigRightCrouchState(container);        }

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
            container.CurrentState = MarioFactory.Instance.CreateBigRightJumpingState(container);

        }

        public void MoveLeft()
        {
            container.CurrentState = MarioFactory.Instance.CreateBigLeftStandingState(container);
        }

        public void MoveRight()
        {
            container.CurrentState = MarioFactory.Instance.CreateBigRightWalkingState(container);
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
            return MarioFactory.Instance.CreateBigRightStandingState(destination);
        }
    }
}
