using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class FlagPoleItem : IItems
    {
        public int Width { get; }
        public int Height { get; }
        ITextureAtlas flag;
        public Rectangle Position { get; set; }
        public Texture2D Texture { get ; set; }
        public Vector2 Location { get; set; }
        public bool isBouncing { get; set; }
        public bool isUsed { get; set; }
        public bool HasEnemyOnIt { get; set; }
        public bool timerStarted { get; set; }
        public bool timerFinished { get; set; }
        public int UsedOnce { get; set; }
        public int yChange { get; set; }
        public int SoundCounter { get; set; }

        private bool falling;


        //private Texture2D flag;
        public FlagPoleItem(ITextureAtlas flagPole, Vector2 pos)
        {
            falling = false;
            timerStarted = false;
            timerFinished = false;
            flag = flagPole;
            SoundCounter = 0;
            Location = new Vector2(pos.X,pos.Y-flag.Height);
            Height = flag.Height;
            Width = flag.Width;
            Position = new Rectangle((int)Location.X, (int)Location.Y, Width, Height);
        }
        public void Bounce()
        {
            //do nothing
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            flag.Draw(spriteBatch, Location);
        }

        public void Update(GameTime gt)
        {
            flag.Update(falling);
        }
        public void Flag()
        {
            falling = true;
        }
    }
}
