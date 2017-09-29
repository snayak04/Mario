using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class NightmareTurtleEnemy : INightmareEnemy
    {
        public Vector2 Location { get; set; }
        public Rectangle Position { get; set; }
        public ITextureAtlas FacingLeft { get; set; }
        public ITextureAtlas FacingRight { get; set; }
        public bool IsVisible { get; set; }
        // dupulicated name: Texture
        public ITextureAtlas Texture { get; set; }
        public bool IsKilled { get; set; }

        //Constants for 4x4 texture atlas
        private bool facingRight;
        private int currentDirection;
        private Vector2 posChange;
        private Vector2 move;
        private int delay = 60;
        private int direction;
        private bool delayFlag;

        public NightmareTurtleEnemy(ITextureAtlas leftTxt, ITextureAtlas rightTxt, Vector2 pos)
        {
            IsKilled = false;
            FacingLeft = leftTxt;
            FacingRight = rightTxt;
            Texture = FacingLeft;
            Location = pos;
            Position = new Rectangle((int)Location.X, (int)Location.Y, FacingLeft.Width, FacingLeft.Height);
            posChange = new Vector2(0, 0);      //posChange used to bounce  enemy in x/y direction
            move = new Vector2(-1, 0);
            delayFlag = false;
            facingRight = true;
        }
        public void Update()
        {
            
                Location += posChange;
                posChange.X = 0;
                posChange.Y = 0;
                Location += move;
            if (facingRight)
            {
                //FacingRight.Update();
            }
            else
            {
                //FacingLeft.Update();
            }
                Position = new Rectangle((int)Location.X, (int)Location.Y, FacingLeft.Width, FacingLeft.Height);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if(facingRight)
            {
                FacingRight.Draw(spriteBatch, Location);
            } else
            {
                FacingLeft.Draw(spriteBatch, Location);
            }
            
        }
        public void Infect()
        {
            //TODO
            int delayFactor = 60;
            if (delayFlag)
            {
                delayFactor = 0;
                delayFlag = false;
            }

            if (delayFactor != delay)
            {
                delayFactor++;
            }

            if (delayFactor == delay)
            {
                // infect
            }
        }

        public void BounceX(int width)
        {
            posChange.X += width;
        }

        public void BounceY(int height)
        {
            posChange.Y += height;
        }

        public void Turn()
        {
            move.X = move.X * (-1);

            facingRight = !facingRight;
        }

        public void TurnLeft()
        {
            if (move.X > 0)
            {
                move.X *= (-1);
                facingRight = !facingRight;
            }
        }

        public void TurnRight()
        {
            if (move.X < 0)
            {
                move.X *= (-1);
                facingRight = !facingRight;
            }
        }

        public void Fall()
        {
            move.Y = 3;
        }

        public void Land()
        {
            move.Y = 0;
        }

        public void Die()
        {
            IsKilled = true;
        }

        public void Delay()
        {
            delayFlag = true;
        }


        
    }
}


