using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class FireMarioRightJumpingState : IMarioState
    {
        private IMario container;
        private ITextureAtlas character;
        public int Width { get; }
        public int Height { get; }
        public bool IsBig { get; }
        public bool IsFire { get; }

        public FireMarioRightJumpingState(IMario mario)
        {
            container = mario;
            character = MarioFactory.fireMarioRightJumpingAtlas;
            Width = character.Width;
            Height = character.Height;
            IsBig = true;
            IsFire = true;
        }

        public void ChangeToBig()
        {
            container.CurrentState = MarioFactory.Instance.CreateBigRightJumpingState(container);
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
            container.CurrentState = MarioFactory.Instance.CreateSmallRightJumpingState(container);
        }

        public void Crouch()
        {
            container.CurrentState = MarioFactory.Instance.CreateFireRightStandingState(container);
        }

        public void Die()
        {
            container.CurrentState = MarioFactory.Instance.CreateBigRightJumpingState(container);
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
            container.CurrentState = MarioFactory.Instance.CreateFireLeftJumpingState(container);
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
            return MarioFactory.Instance.CreateFireRightJumpingState(destination);
        }
    }
}
