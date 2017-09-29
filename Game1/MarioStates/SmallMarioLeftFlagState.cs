using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class SmallLeftFlagState : IMarioState
    {
        IMario container;
        ITextureAtlas character;
        public int Height { get; }
        public int Width { get; }
        public bool IsBig { get; }
        public bool IsFire { get; }

        public SmallLeftFlagState(IMario mario)
        {
            container = mario;
            character = MarioFactory.smallMarioLeftFlagAtlas;
            Width = character.Width;
            Height = character.Height;
            IsBig = false;
            IsFire = false;
            container.FacingRight = true;
        }
        public void ChangeToBig()
        {
            //throw new NotImplementedException();
        }

        public void ChangeToFire()
        {
            //throw new NotImplementedException();
        }

        public void ChangeToInvincible()
        {
            //throw new NotImplementedException();
        }

        public void ChangeToSmall()
        {
            //throw new NotImplementedException();
        }

        public IMarioState clone(IMario destination)
        {
            //throw new NotImplementedException();
            return MarioFactory.Instance.CreateSmallLeftFlagState(destination);
        }

        public void Crouch()
        {
            //throw new NotImplementedException();
        }

        public void Die()
        {
            //throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 pos)
        {
            character.Draw(spriteBatch, pos);
        }

        public void Jump()
        {
            //throw new NotImplementedException();
        }

        public void MoveLeft()
        {
            //throw new NotImplementedException();
        }

        public void MoveRight()
        {
            //throw new NotImplementedException();
        }

        public void StopJumpingFalling()
        {
            //throw new NotImplementedException();
        }

        public void StopWalking()
        {
            //throw new NotImplementedException();
        }

        public void Update()
        {
            //throw new NotImplementedException();
        }
    }
}
