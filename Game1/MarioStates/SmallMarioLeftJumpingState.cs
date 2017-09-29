using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class SmallMarioLeftJumpingState : IMarioState
    {
        IMario container;
        ITextureAtlas character;
        public int Height { get; }
        public int Width { get; }
        public bool IsBig { get; }
        public bool IsFire { get; }

        public SmallMarioLeftJumpingState(IMario mario)
        {
            container = mario;
            character = MarioFactory.smallMarioLeftJumpingAtlas;
            Height = character.Height;
            Width = character.Width;
            IsBig = false;
            IsFire = false;
            container.FacingRight = false;
        }

        public void ChangeToFire()
        {
            container.CurrentState = MarioFactory.Instance.CreateFireLeftJumpingState(container);  
        }

        public void ChangeToInvincible()
        {
            //Do nothing 
        }

        public void ChangeToBig()
        {
            container.CurrentState = MarioFactory.Instance.CreateBigLeftJumpingState(container);
        }

        public void ChangeToSmall()
        {
            //Do nothing
        }

        public void Crouch()
        {
            container.CurrentState = MarioFactory.Instance.CreateSmallLeftStandingState(container);
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
            //Do nothing
        }

        public void MoveLeft()
        {
            //Do nothing
        }

        public void MoveRight()
        {
            container.CurrentState = MarioFactory.Instance.CreateSmallRightJumpingState(container); 
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
            container.CurrentState = MarioFactory.Instance.CreateSmallLeftStandingState(container);
        }

        public IMarioState clone(IMario destination)
        {
            return MarioFactory.Instance.CreateSmallLeftJumpingState(destination);
        }
    }
}
