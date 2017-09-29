using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class SmallMarioRightStandingState : IMarioState
    {
        IMario container;
        ITextureAtlas character;
        public int Width { get; }
        public int Height { get; }
        public bool IsBig { get; }
        public bool IsFire { get; }

        public SmallMarioRightStandingState(IMario mario)
        {
            container = mario;
            character = MarioFactory.smallMarioRightStandingAtlas;
            Width = character.Width;
            Height = character.Height;
            IsBig = false;
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
            container.CurrentState = MarioFactory.Instance.CreateBigRightStandingState(container);
        }

        public void ChangeToSmall()
        {
            //Do nothing
        }

        public void Crouch()
        {
            container.CurrentState = MarioFactory.Instance.CreateSmallRightCrouchingState(container);
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
            container.CurrentState = MarioFactory.Instance.CreateSmallRightJumpingState(container);
        }

        public void MoveLeft()
        {
            container.CurrentState = MarioFactory.Instance.CreateSmallLeftStandingState(container);
        }

        public void MoveRight()
        {
            container.CurrentState = MarioFactory.Instance.CreateSmallRightWalkingState(container);
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
            return MarioFactory.Instance.CreateSmallRightStandingState(destination);
        }
    }
}
