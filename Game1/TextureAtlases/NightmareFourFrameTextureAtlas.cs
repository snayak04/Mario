using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class NightmareFourFrameTextureAtlas : ITextureAtlas
    {
        private Texture2D texture;
        public int Width { get; }
        public int Height { get; }
        private int currentFrame = 0;
        private int bufferRate = 5;
        private int buffer = 0;
        private int totalFrames = 3;

        public NightmareFourFrameTextureAtlas(Texture2D texture)
        {
            this.texture = texture;
            Width = texture.Bounds.Width / 2;
            Height = texture.Bounds.Height / 2;
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == 2)
            {
                currentFrame = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 pos)
        {
            Rectangle source = new Rectangle((currentFrame * Width), 0, Width, Height);
            Rectangle destination = new Rectangle((int)pos.X, (int)pos.Y - Height, Width, Height);
            spriteBatch.Draw(texture, destination, source, Color.DarkGray);
        }

        public void Update(bool falling)
        {
            //throw new NotImplementedException();
        }
    }
}
