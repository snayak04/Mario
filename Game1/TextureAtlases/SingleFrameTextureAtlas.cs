using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class SingleFrameTextureAtlas : ITextureAtlas
    {
        private Texture2D texture;
        public int Width { get; }
        public int Height { get; }

        public SingleFrameTextureAtlas(Texture2D textureInput)
        {
            texture = textureInput;
            Width = textureInput.Bounds.Width;
            Height = textureInput.Bounds.Height;
        } 

        public void Draw(SpriteBatch spriteBatch, Vector2 pos)
        {
            Rectangle source = new Rectangle(0, 0, Width, Height);
            Rectangle destination = new Rectangle((int)pos.X, (int)pos.Y-Height, Width, Height);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }

        public void Update()
        {
           //do nothing 
        }

        public void Update(bool falling)
        {
            //throw new NotImplementedException();
        }
    }
}
