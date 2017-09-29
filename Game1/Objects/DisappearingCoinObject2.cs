using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class DisappearingCoinObject2 : IObject
    {
        ITextureAtlas obj;
        private int Width { get; }
        private int Height { get; }
        //private int Rows = 1;
        //private int Columns = 3;
        //private int totalFrames = 3;
        //private int currentFrame = 0;
        //private int delay = 0;
        public bool IsUsed { get; set; }
        public Rectangle Position { get; set; }
        public Vector2 Location { get; set; }
        private Vector2 positionChange;
        private int counter;

        public DisappearingCoinObject2(ITextureAtlas texture, Vector2 pos)
        {
            obj = texture;
            Location = pos;
            IsUsed = false;
            Height = obj.Height;
            Width = obj.Width;
            positionChange = pos;
            counter = 0;
            Position = new Rectangle((int)Location.X, (int)Location.Y, Width, Height);
        }

        public void Update()
        {
            counter++;
            positionChange.Y -= 2;
            Location  = positionChange;
            obj.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(counter < 7)
            {
                Position = new Rectangle((int)Location.X, (int)Location.Y, Width, Height);
                obj.Draw(spriteBatch, Location);
            }
        }

        public void BounceX(int width)
        {

        }

        public void BounceY(int height)
        {

        }

        public void Turn()
        {

        }

        public void TurnY()
        {

        }

        public void Fall()
        {

        }

        public void Land()
        {

        }
    }
}
