using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game1
{
    class BigMarioRightJumpingState : IMarioState
    {
        IMario container;
        ITextureAtlas character;
        public int Width { get; }
        public int Height { get; }
        public bool IsBig { get; }
        public bool IsFire { get; }
        public BigMarioRightJumpingState(IMario mario)
        {
            container = mario;
            character = MarioFactory.bigMarioRightJumpingAtlas;
            Width = character.Width;
            Height = character.Height;
            IsBig = true;
            IsFire = false;
        }

        public void ChangeToBig()
        {
            //Do nothing
        }

        public void ChangeToFire()
        {
            container.CurrentState = MarioFactory.Instance.CreateFireRightJumpingState(container);
        }

        public void ChangeToInvincible()
        {
            //Do nothing
        }

        public void ChangeToSmall()
        {
            container.CurrentState = MarioFactory.Instance.CreateSmallRightJumpingState(container);
        }

        public void Crouch()
        {
            container.CurrentState = MarioFactory.Instance.CreateBigRightStandingState(container);
        }

        public void Die()
        {
            container.CurrentState = MarioFactory.Instance.CreateSmallRightJumpingState(container);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 pos)
        {
            character.Draw(spriteBatch, pos);
        }

        public void Jump()
        {
            //Do nothing
        }

        public void MoveLeft()
        {
            container.CurrentState = MarioFactory.Instance.CreateBigLeftJumpingState(container);
        }

        public void MoveRight()
        {
            //Do nothing
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
            container.CurrentState = MarioFactory.Instance.CreateBigRightStandingState(container);
        }
        public IMarioState clone(IMario destination)
        {
            return MarioFactory.Instance.CreateBigRightJumpingState(destination);
        }
    }
}
