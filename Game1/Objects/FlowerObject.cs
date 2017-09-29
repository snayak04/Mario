using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class FlowerObject : IObject
    {
        ITextureAtlas obj;
        public Vector2 Location { get; set; }
        public int Width { get;  }
        public int Height { get; }
        public bool IsUsed { get; set; }
        public Rectangle Position { get; set; }

        public FlowerObject(ITextureAtlas texture, Vector2 pos)
        {
            obj = texture;
            Width = obj.Width;
            Height = obj.Height;
            Location = pos;
            IsUsed = false;
            Position = new Rectangle((int)Location.X, (int)Location.Y, Width, Height);
        }

        public void Update()
        {
            obj.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Position = new Rectangle((int)Location.X, (int)Location.Y, Width, Height);
            obj.Draw(spriteBatch, Location);
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
