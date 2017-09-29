using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class NightmareThreeFrameTextureAtlas : ITextureAtlas
    {
        private Texture2D texture;
        public int Width { get; }
        public int Height { get; }
        private int currentFrame = 1;
        private int bufferRate= 10;
        private int buffer = 0;
        private int totalFrames = 3;

        public NightmareThreeFrameTextureAtlas(Texture2D texture)
        {
            this.texture = texture;  
            Width = texture.Bounds.Width / 3;
            Height = texture.Bounds.Height;
        }

        public void Update()
        {
            if (buffer == bufferRate)
            {
                currentFrame++;
                if (currentFrame == totalFrames)
                    currentFrame = 1;
                buffer = 0;                
            }
            buffer++;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 pos)
        {
            Rectangle source = new Rectangle((currentFrame * Width), 0, Width, Height);
            Rectangle destination = new Rectangle((int)pos.X, (int)pos.Y - Height, Width, Height);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }

        public void Update(bool falling)
        {
            //throw new NotImplementedException();
        }
    }
}
