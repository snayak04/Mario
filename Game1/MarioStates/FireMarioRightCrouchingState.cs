using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class FireMarioRightCrouchingState : IMarioState
    {
        IMario container;
        ITextureAtlas character;
        public int Height { get;}
        public int Width { get; }
        public bool IsBig { get; }
        public bool IsFire { get; }

        public FireMarioRightCrouchingState(IMario mario)
        {
            container = mario;
            character = MarioFactory.fireMarioRightCrouchingAtlas;
            Height = character.Height;
            Width = character.Width;
            IsBig = true;
            IsFire = true;
        }

        public void ChangeToBig()
        {
            container.CurrentState = MarioFactory.Instance.CreateBigRightCrouchState(container);
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
            container.CurrentState = MarioFactory.Instance.CreateSmallRightStandingState(container);
        }

        public void Crouch()
        {
            //Do nothing
        }

        public void Die()
        {
            container.CurrentState = MarioFactory.Instance.CreateBigRightCrouchState(container);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 pos)
        {
            character.Draw(spriteBatch, pos);
        }

        public void Jump()
        {
            container.CurrentState = MarioFactory.Instance.CreateFireRightStandingState(container);
        }

        public void MoveLeft()
        {
            container.CurrentState = MarioFactory.Instance.CreateFireLeftCrouchingState(container);
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
            container.CurrentState = MarioFactory.Instance.CreateFireRightStandingState(container);
        }
        public IMarioState clone(IMario destination)
        {
            return MarioFactory.Instance.CreateFireRightCrouchingState(destination);
        }
    }
}
