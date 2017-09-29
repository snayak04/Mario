using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game1
{
    class UsedBlockItem : IItems
    {
        public int Width { get; }
        public int Height { get; }
        public Texture2D Texture { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle Position { get; set; }
        public int yChange { get; set; }
        public bool isBouncing { get; set; }
        public bool isUsed { get; set; }
        public bool timerStarted { get; set; }
        public bool timerFinished { get; set; }
        public int UsedOnce { get; set; }
        public bool HasEnemyOnIt { get; set;}
        public int SoundCounter { get; set; }

        private Vector2 bouncePosition;
        private int downCount;
        private int upCount;
        private int maxCount;

        public UsedBlockItem(Texture2D texture, Vector2 pos)
        {
            Texture = texture;
            Location = pos;
            bouncePosition = pos;
            yChange = 3;
            isBouncing = false;
            isUsed = false;
            HasEnemyOnIt = false;
            timerFinished = false;
            UsedOnce = 0;
            downCount = 0;
            upCount = 0;
            maxCount = 3;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Position = new Rectangle((int)bouncePosition.X, (int)bouncePosition.Y, Texture.Width , Texture.Height );
            spriteBatch.Draw(Texture, bouncePosition, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
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
                    this.UsedOnce++;
                    this.isBouncing = false;
                }
            }
        }
        public void Bounce()
        {
            this.isBouncing = true;
        }
        public void Flag() { }
    }
}
