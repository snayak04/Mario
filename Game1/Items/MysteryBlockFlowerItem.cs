using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game1
{
    class MysteryBlockFlowerItem : IItems

    {
        public int Width { get; }
        public int Height { get; }
        public Texture2D Texture { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle Position { get; set; }
        public int yChange { get; set; }
        public bool isBouncing { get; set; }
        public bool isUsed { get; set; }
        public bool HasEnemyOnIt { get; set; }
        public bool timerStarted { get; set; }
        public bool timerFinished { get; set; }
        public int UsedOnce { get; set; }
        public int SoundCounter { get; set; }

        private int Rows = 1;
        private int Columns = 3;
        private int currentFrame = 0;
        private int totalFrames = 3;
        private int delay = 0;

        public MysteryBlockFlowerItem(Texture2D texture, Vector2 pos)
        {
            Texture = texture;
            Location = pos;
            yChange = 3;
            isBouncing = false;
            isUsed = false;
            HasEnemyOnIt = false;
            timerStarted = false;
            timerFinished = false;
            UsedOnce = 0;
        }
        public void Bounce()
        {
            this.isBouncing = true;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Position = new Rectangle((int)Location.X, (int)Location.Y, Texture.Width / Columns, Texture.Height / Rows);
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)Location.X, (int)Location.Y, width, height);

            //spriteBatch.Begin();
            spriteBatch.Draw(Texture, Location, sourceRectangle, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            //spriteBatch.End();
        }
        public void Update(GameTime gt)
        {
            delay++;
            if (delay == 10)
            {
                currentFrame++;
                if (currentFrame == totalFrames)
                    currentFrame = 0;
                delay = 0;
            }
        }
        public void Flag() { }
    }
}
