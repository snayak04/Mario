using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class HiddenBlockItem : IItems
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

        public Vector2 bouncePosition;
        private int Rows = 1;
        private int Columns = 2;
        private int currentFrame = 0;
        private int upCount, downCount, maxCount;

        public HiddenBlockItem(Texture2D texture, Vector2 pos)
        {
            Texture = texture;
            Location = pos;
            bouncePosition = pos;
            yChange = 3;
            isBouncing = false;
            isUsed = false;
            HasEnemyOnIt = false;
            timerStarted = false;
            timerFinished = false;
            UsedOnce = 0;
            downCount = 0;
            upCount = 0;
            maxCount = 3;
        }
        public void Bounce()
        {
            this.isBouncing = true;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Position = new Rectangle((int)bouncePosition.X, (int)bouncePosition.Y, Texture.Width / Columns, Texture.Height / Rows);
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)bouncePosition.X, (int)bouncePosition.Y, width, height);

            //spriteBatch.Begin();
            spriteBatch.Draw(Texture, Location, sourceRectangle, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            //spriteBatch.End();
        }
        public void Update(GameTime gt)
        {
            if (this.isBouncing)
            {
                if ((upCount < maxCount) && (downCount < maxCount)) //upCount counter used to manage the number of times sprite is moved up
                {
                    bouncePosition.Y -= yChange;
                    upCount++;
                }
                else if ((downCount < maxCount) && (upCount >= maxCount))  //downCount counter used to manage the number of times sprite is moved down
                {
                    bouncePosition.Y += yChange;
                    downCount++;
                }
                else
                {
                    bouncePosition.Y = Location.Y;
                    upCount = 0;
                    downCount = 0;
                    this.isBouncing = false;
                }
            }
        }
        public void Flag() { }
    }
}
