using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class FireMarioLeftStandingState : IMarioState
    {
        private IMario container;
        private ITextureAtlas character;
        public int Width { get; }
        public int Height { get; }
        public bool IsBig { get; }
        public bool IsFire { get; }


        public FireMarioLeftStandingState(IMario mario)
        {
            container = mario;
            character = MarioFactory.fireMarioLeftStandingAtlas;
            Width = character.Width;
            Height = character.Height;
            IsBig = true;
            IsFire = true;
            container.FacingRight = false;
        }
        public void ChangeToBig()
        {
            container.CurrentState = MarioFactory.Instance.CreateBigLeftStandingState(container);
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
            container.CurrentState = MarioFactory.Instance.CreateFireLeftCrouchingState(container);
        }

        public void Die()
        {
            container.CurrentState = MarioFactory.Instance.CreateBigLeftStandingState(container);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 pos)
        {
            character.Draw(spriteBatch, pos);
        }

        public void Jump()
        {
            container.CurrentState = MarioFactory.Instance.CreateFireLeftJumpingState(container);
        }

        public void MoveLeft()
        {
            container.CurrentState = MarioFactory.Instance.CreateFireLeftWalkingState(container);
        }

        public void MoveRight()
        {
            container.CurrentState = MarioFactory.Instance.CreateFireRightStandingState(container);
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
            return MarioFactory.Instance.CreateFireLeftStandingState(destination);
        }
    }
}
