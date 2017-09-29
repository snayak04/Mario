using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game1
{
    class BigRightWalkingState : IMarioState
    {
        IMario container;
        ITextureAtlas character;
        public int Width { get; }
        public int Height { get; }
        public bool IsBig { get; }
        public bool IsFire { get; }

        public BigRightWalkingState(IMario mario)
        {
            container = mario;
            character = MarioFactory.bigMarioRightWalkingAtlas;
            Width = character.Width;
            Height = character.Height;
            IsBig = true;
            IsFire = false;
        }

        public void ChangeToFire()
        {
            container.CurrentState = MarioFactory.Instance.CreateFireRightWalkingState(container);
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
            container.CurrentState = MarioFactory.Instance.CreateSmallRightWalkingState(container);
        }

        public void Crouch()
        {
            container.CurrentState = MarioFactory.Instance.CreateBigRightCrouchState(container);
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
            container.CurrentState = MarioFactory.Instance.CreateBigRightJumpingState(container);

        }

        public void MoveLeft()
        {
            container.CurrentState = MarioFactory.Instance.CreateBigRightStandingState(container);
        }

        public void MoveRight()
        {
            // Do nothing
        }

        public void Update()
        {
            character.Update();
        }
        public void StopWalking()
        {
            container.CurrentState = MarioFactory.Instance.CreateBigRightStandingState(container);
        }
        public void StopJumpingFalling()
        {
            //Do nothing
        }
        public IMarioState clone(IMario destination)
        {
            return MarioFactory.Instance.CreateBigRightWalkingState(destination);
        }
    }
}
