using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class FireMarioLeftWalkingState : IMarioState
    {
        private IMario container;
        private ITextureAtlas character;
        public int Width { get; }
        public int Height { get; }
        public bool IsBig { get; }
        public bool IsFire { get; }

        public FireMarioLeftWalkingState(IMario mario)
        {
            container = mario;
            character = MarioFactory.fireMarioLeftWalkingAtlas;
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
            container.CurrentState = MarioFactory.Instance.CreateSmallLeftWalkingState(container);
        }

        public void Crouch()
        {
            container.CurrentState = MarioFactory.Instance.CreateFireLeftCrouchingState(container);
        }

        public void Die()
        {
            container.CurrentState = MarioFactory.Instance.CreateBigLeftWalkingState(container);
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
            //Do nothing
        }

        public void MoveRight()
        {
            container.CurrentState = MarioFactory.Instance.CreateFireLeftStandingState(container);
        }

        public void Update()
        {
            character.Update();
        }
        public void StopWalking()
        {
            container.CurrentState = MarioFactory.Instance.CreateFireLeftStandingState(container);
        }
        public void StopJumpingFalling()
        {
            //Do nothing
        }
        public IMarioState clone(IMario destination)
        {
            return MarioFactory.Instance.CreateFireLeftWalkingState(destination);
        }
    }
}
