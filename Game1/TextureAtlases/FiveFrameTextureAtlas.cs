using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class FiveFrameTextureAtlas : ITextureAtlas
    {
        private Texture2D texture;
        public int Height { get; }

        public int Width { get; }

        private int currentFrame = 0;
        private int bufferRate = 10;
        private int buffer = 0;
        private int totalFrames = 5;

        public FiveFrameTextureAtlas(Texture2D texture)
        {
            this.texture = texture;
            Width = texture.Bounds.Width / 5;
            Height = texture.Bounds.Height;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 pos)
        {
            Rectangle source = new Rectangle((currentFrame * Width), 0, Width, Height);
            Rectangle destination = new Rectangle((int)pos.X, (int)pos.Y, Width, Height);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }

        public void Update(bool falling)
        {
            if (buffer == bufferRate)
            {
                if (!falling)
                {
                    currentFrame = totalFrames -1;
                }
                else
                {
                    if (currentFrame != 0)
                    {
                        currentFrame--;
                    }
                }
                buffer = 0;
            }
            buffer++;
        }

        public void Update()
        {
            //throw new NotImplementedException();
        }
    }
}
