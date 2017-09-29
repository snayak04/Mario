using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class FourFrameTextureAtlas : ITextureAtlas
    {
        private Texture2D texture;
        public int Width { get; }
        public int Height { get; }
        private int currentFrame = 0;
        private int bufferRate = 5;
        private int buffer = 0;
        private int totalFrames = 4;

        public FourFrameTextureAtlas(Texture2D texture)
        {
            this.texture = texture;
            Width = texture.Bounds.Width / 4;
            Height = texture.Bounds.Height;
        }

        public void Update()
        {            
            if (buffer == bufferRate)
            {
                currentFrame++;
                if (currentFrame == totalFrames-1)
                    currentFrame = 0;
                buffer = 0;
            }
            buffer++;           
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 pos)
        {
            Rectangle source = new Rectangle((currentFrame * Width), 0, Width, Height);
            Rectangle destination = new Rectangle((int)pos.X, (int)pos.Y, Width, Height);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }

        public void Update(bool falling)
        {
            //throw new NotImplementedException();
        }
    }
}
