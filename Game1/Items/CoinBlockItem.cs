using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game1
{
    class CoinBlockItem : IItems
    {
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
        public int Width { get; set; }
        public int Height { get; set; }
        public int SoundCounter { get; set; }

        private Vector2 bouncePosition;
        private int downCount;
        private int upCount;
        private int maxCount;
        private double timer;

        public CoinBlockItem(Texture2D texture, Vector2 pos)
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
            timer = 5;
        }

        public void Bounce()
        {
            this.isBouncing = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Position = new Rectangle((int)bouncePosition.X, (int)bouncePosition.Y, Texture.Width, Texture.Height);
            spriteBatch.Draw(Texture, bouncePosition, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
        public void Update(GameTime gt)
        {
            if(timerStarted) {
                timer -= gt.ElapsedGameTime.TotalSeconds;
                if (this.isBouncing)
                {
                    if (timer > 0)
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
                    else
                    {
                        timerFinished = true;
                    }
                }
            }   
        }

        public void Flag()
        {
            throw new NotImplementedException();
        }
    }
}
