using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class StarObject : IObject
    {
        ITextureAtlas obj;
        private int Width { get; }
        private int Height { get; }
        public bool IsUsed { get; set; }
        public Rectangle Position { get; set; }
        public Vector2 Location { get; set; }
        private Vector2 move;
        private Vector2 posChange;
        //private int xChange;
        //private int yChange;

        private int upCount;
        private const int MAX_COUNT = 3;

        //Gravity related stuff
        private const int ACCELARATION_DELAY = 15;
        private int accCount;
        private const int MAX_FALL = 2;

        public StarObject(ITextureAtlas txt, Vector2 pos)
        {
            obj = txt;
            Location = pos;
            IsUsed = false;
            Height = obj.Height;
            Width = obj.Width;
            upCount = 0;
            accCount = 0;
            Position = new Rectangle((int)Location.X, (int)Location.Y, Width, Height);
            move = new Vector2(2, -4);
        }

        public void Update()      
        {
            Location += posChange;
            posChange.X = 0;
            posChange.Y = 0;
            Location += move;
            accCount++;
            if(accCount == ACCELARATION_DELAY)  //this is not worked out correctly
            { 
                if(upCount < MAX_COUNT)
                {
                    this.TurnY();
                    upCount = 0;
                }
            }
               
            Position = new Rectangle((int)Location.X, (int)Location.Y, Width, Height);
            obj.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            obj.Draw(spriteBatch, Location);
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
        }

        public void TurnY()
        {
            move.Y = move.Y * (-1);
        }

        public void Fall()
        {
            move.Y = 3;
        }

        public void Land()
        {
            move.Y = 0;
        }
    }
}
