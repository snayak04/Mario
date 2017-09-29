using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class RedMushroomObject : IObject
    {
        private ITextureAtlas obj;
        public bool IsUsed { get; set; }
        public Rectangle Position { get; set; }
        public Vector2 Location { get; set; }
        private Vector2 locale;
        private Vector2 move;
        private Vector2 posChange;

        public RedMushroomObject(ITextureAtlas txt, Vector2 pos)
        {
            obj = txt;
            Location = pos;
            locale = pos;
            IsUsed = false;
            Position = new Rectangle((int)Location.X, (int)Location.Y, obj.Width, obj.Height);
            move = new Vector2(1, 0);
        }

        public void Update()      
        {
            Location += posChange;
            posChange.X = 0;
            posChange.Y = 0;

            Location += move;
            //obj.Update();
            Position = new Rectangle((int)Location.X, (int)Location.Y, obj.Width, obj.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            locale.Y = Location.Y + obj.Height;
            locale.X = Location.X;
            obj.Draw(spriteBatch, locale);
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
