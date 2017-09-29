using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class BrickBlockPiecesExplodingHighRightItem : IItems
    {
        public int Width { get; }
        public int Height { get; }
        public Texture2D Texture { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle Position { get; set; }
        public bool isBouncing { get; set; }
        public bool isUsed { get; set; }
        public bool HasEnemyOnIt { get; set; }
        public bool timerStarted { get; set; }
        public bool timerFinished { get; set; }
        public int UsedOnce { get; set; }
        public int yChange { get; set; }
        public int SoundCounter { get; set; }
        public int xChange;

        private Vector2 ExplodingPosition;
        private int downCount;
        private int upCount;
        private int maxUpCount;
        private int maxDownCount;

        public BrickBlockPiecesExplodingHighRightItem(Texture2D texture, Vector2 pos)
        {
            Texture = texture;
            Location = pos;
            ExplodingPosition = pos;
            isBouncing = false;
            isUsed = false;
            HasEnemyOnIt = false;
            timerStarted = false;
            timerFinished = false;  
            UsedOnce = 0;
            downCount = 0;
            upCount = 0;
            maxUpCount = 10;
            maxDownCount = 300;
            yChange = 9;
            xChange = 2;
        }
        public void Bounce()
        {
            //do nothing;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Position = new Rectangle((int)ExplodingPosition.X, (int)ExplodingPosition.Y, Texture.Width, Texture.Height);
            //spriteBatch.Begin();
            spriteBatch.Draw(Texture, ExplodingPosition, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            //spriteBatch.End();
        }

        public void Update(GameTime gt)
        {
            if ((upCount < maxUpCount) && (downCount < maxDownCount)) //upCount counter used to manage the number of times sprite is moved up
            {
                ExplodingPosition.X += xChange;
                ExplodingPosition.Y -= yChange;
                upCount++;
            }
            else if ((downCount < maxDownCount) && (upCount >= maxUpCount))  //downCount counter used to manage the number of times sprite is moved down
            {
                ExplodingPosition.X += xChange;
                ExplodingPosition.Y += yChange;
                downCount++;
            }
            else
            {
                this.isUsed = true;
            }
        }
        public void Flag() { }
    }
}
