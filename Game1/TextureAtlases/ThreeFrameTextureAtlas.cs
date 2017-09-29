using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class ThreeFrameTextureAtlas : ITextureAtlas
    {
        private Texture2D texture;

        public int Width { get; }
        public int Height { get; }
        private int currentFrame = 1;
        private int bufferRate = 5;
        private int buffer = 0;
        private int totalFrames = 3;
        private int direction = 1;

        public ThreeFrameTextureAtlas(Texture2D texture)
        {
            this.texture = texture;
            Width = texture.Bounds.Width / 3;
            Height = texture.Bounds.Height;
        }

        public void Update()
        {
            if(currentFrame == totalFrames)
            {
                direction = -1;
            } else if (currentFrame == 1)
            {
                direction = 1;
            }

            if(buffer == bufferRate)
            {
                currentFrame += direction;
                buffer = 0;
            }
            else
            {
                buffer++;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 pos)
        {
            Rectangle source = new Rectangle((currentFrame-1) * Width, 0, Width, Height);
            Rectangle destination = new Rectangle((int)pos.X, (int)pos.Y - Height, Width, Height);

            spriteBatch.Draw(texture, destination, source, Color.White);
        }

        public void Update(bool falling)
        {
            //throw new NotImplementedException();
        }
    }
}
