using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class SmallMarioDeadState : IMarioState
    {
        IMario container;
        ITextureAtlas character;
        public int Height { get;}
        public int Width { get; }
        public bool IsBig { get; }
        public bool IsFire { get; }

        public SmallMarioDeadState(IMario mario)
        {
            container = mario;
            character = MarioFactory.smallMarioDeadAtlas;
            Height = character.Height;
            Width = character.Width;
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
            container.CurrentState = MarioFactory.Instance.CreateSmallRightStandingState(container);
        }

        public void Crouch()
        {
            //Do nothing
        }

        public void Die()
        {
            //Do nothing
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
            //Do nothing
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
            //Do nothing
        }
        public IMarioState clone(IMario destination)
        {
            return MarioFactory.Instance.CreateSmallDeadState(destination);
        }
    }
}
