using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class SmallMarioLeftStandingState : IMarioState
    {
        IMario container;
        ITextureAtlas character;
        public int Height { get; }
        public int Width { get; }
        public bool IsBig { get; }
        public bool IsFire { get; }
        public SmallMarioLeftStandingState(IMario mario)
        {
            container = mario;
            character = MarioFactory.smallMarioLeftStandingAtlas;
            Height = character.Height;
            Width = character.Width;
            IsBig = false;
            IsFire = false;
            container.FacingRight = false;
        }

        public void ChangeToFire()
        {
            container.CurrentState = MarioFactory.Instance.CreateFireLeftStandingState(container);
        }

        public void ChangeToInvincible()
        {
            //Do nothing
        }

        public void ChangeToBig()
        {
            container.CurrentState = MarioFactory.Instance.CreateBigLeftStandingState(container);
        }

        public void ChangeToSmall()
        {
            //Do nothing
        }

        public void Crouch()
        {
            container.CurrentState = MarioFactory.Instance.CreateSmallLeftCrouchingState(container);
        }

        public void Die()
        {
            container.CurrentState = MarioFactory.Instance.CreateSmallDeadState(container);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 pos)
        {
            character.Draw(spriteBatch, pos); 
        }

        public void Jump()
        {
            container.CurrentState = MarioFactory.Instance.CreateSmallLeftJumpingState(container);
        }

        public void MoveLeft()
        {
            container.CurrentState = MarioFactory.Instance.CreateSmallLeftWalkingState(container);
        }

        public void MoveRight()
        {
            container.CurrentState = MarioFactory.Instance.CreateSmallRightStandingState(container);
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
            return MarioFactory.Instance.CreateSmallLeftStandingState(destination);
        }
    }
}
