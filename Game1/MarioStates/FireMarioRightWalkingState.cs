using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class FireMarioRightWalkingState : IMarioState
    {
        private IMario container;
        private ITextureAtlas character;
        public int Width { get; }
        public int Height { get; }
        public bool IsBig { get; }
        public bool IsFire { get; }

        public FireMarioRightWalkingState(IMario mario)
        {
            container = mario;
            character = MarioFactory.fireMarioRightWalkingAtlas;
            Width = character.Width;
            Height = character.Height;
            IsFire = true;
            IsBig = true;
        }

        public void ChangeToBig()
        {
            container.CurrentState = MarioFactory.Instance.CreateBigRightWalkingState(container);
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
            container.CurrentState = MarioFactory.Instance.CreateSmallRightWalkingState(container);
        }

        public void Crouch()
        {
            container.CurrentState = MarioFactory.Instance.CreateFireRightCrouchingState(container);
        }

        public void Die()
        {
            container.CurrentState = MarioFactory.Instance.CreateBigRightWalkingState(container);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 pos)
        {
            character.Draw(spriteBatch, pos);
        }

        public void Jump()
        {
            container.CurrentState = MarioFactory.Instance.CreateFireRightJumpingState(container);
        }

        public void MoveLeft()
        {
            container.CurrentState = MarioFactory.Instance.CreateFireRightStandingState(container);
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
            container.CurrentState = MarioFactory.Instance.CreateFireRightStandingState(container);
        }
        public void StopJumpingFalling()
        {
            //Do nothing
        }
        public IMarioState clone(IMario destination)
        {
            return MarioFactory.Instance.CreateFireRightWalkingState(destination);
        }
    }
}
