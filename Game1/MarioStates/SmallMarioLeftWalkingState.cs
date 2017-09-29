using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class SmallMarioLeftWalkingState : IMarioState
    {
        IMario container;
        ITextureAtlas character;
        public int Height { get; }
        public int Width { get; }
        public bool IsBig { get; }
        public bool IsFire { get; }
        public SmallMarioLeftWalkingState(IMario mario)
        {
            container = mario;
            character = MarioFactory.smallMarioLeftWalkingAtlas;
            Height = character.Height;
            Width = character.Width;
            IsBig = false;
            IsFire = false;
            container.FacingRight = false;
        }

        public void ChangeToFire()
        {
            container.CurrentState = MarioFactory.Instance.CreateFireLeftWalkingState(container);
        }

        public void ChangeToInvincible()
        {
            //Do nothing
        }

        public void ChangeToBig()
        {
            container.CurrentState = MarioFactory.Instance.CreateBigLeftWalkingState(container);
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
            //Do nothing
        }

        public void MoveRight()
        {
            container.CurrentState = MarioFactory.Instance.CreateSmallLeftStandingState(container);
        }

        public void Update()
        {
            character.Update();
        }
        public void StopWalking()
        {
            container.CurrentState = MarioFactory.Instance.CreateSmallLeftStandingState(container);
        }
        public void StopJumpingFalling()
        {
            //Do nothing
        }
        public IMarioState clone(IMario destination)
        {
            return MarioFactory.Instance.CreateSmallLeftWalkingState(destination);
        }
    }
}
