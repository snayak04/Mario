using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class FireMarioLeftCrouchingState : IMarioState
    {
        private IMario container;
        private ITextureAtlas character;
        public int Width { get; }
        public int Height { get; }
        public bool IsBig { get; }
        public bool IsFire { get; }

        public FireMarioLeftCrouchingState(IMario mario)
        {
            container = mario;
            character = MarioFactory.fireMarioLeftCrouchingAtlas;
            Width = character.Width;
            Height = character.Height;
            IsBig = true;
            IsFire = true;
            container.FacingRight = false;
        }

        public void ChangeToBig()
        {
            container.CurrentState = MarioFactory.Instance.CreateBigLeftCrouchState(container);
        }

        public void ChangeToFire()
        {
            //Do nothing
        }

        public void ChangeToInvincible()
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
            container.CurrentState = MarioFactory.Instance.CreateBigLeftCrouchState(container);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 pos)
        {
            character.Draw(spriteBatch, pos);
        }

        public void Jump()
        {
            container.CurrentState = MarioFactory.Instance.CreateFireLeftStandingState(container);
        }

        public void MoveLeft()
        {
            //Do nothing
        }

        public void MoveRight()
        {
            container.CurrentState = MarioFactory.Instance.CreateFireRightCrouchingState(container);
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
            container.CurrentState = MarioFactory.Instance.CreateFireLeftStandingState(container);
        }
        public IMarioState clone(IMario destination)
        {
            return MarioFactory.Instance.CreateFireLeftCrouchingState(destination);
        }
    }
}
