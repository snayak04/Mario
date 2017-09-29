﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class PipeItem : IItems
    {
        public int Width { get; }
        public int Height { get; }
        public Texture2D Texture { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle Position {get;set;}
        public bool isBouncing { get; set; }
        public bool isUsed { get; set; }
        public bool timerStarted { get; set; }
        public bool timerFinished { get; set; }
        public int yChange { get;  set; }
        public int UsedOnce { get; set; }
        public bool HasEnemyOnIt { get; set; }
        public int SoundCounter { get; set; }

        public PipeItem(Texture2D texture, Vector2 pos)
        {
            Texture = texture;
            Location = pos;
            isBouncing = false;
            isUsed = false;
            HasEnemyOnIt = false;
            timerStarted = false;
            timerFinished = false;
            yChange = 0;
            UsedOnce = 0;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Position = new Rectangle((int)Location.X, (int)Location.Y, Texture.Width , Texture.Height);
            spriteBatch.Draw(Texture, Location, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
        public void Update(GameTime gt)
        {
            //do nothing
        }
        public void Bounce()
        {
            //do nothing
        }
        public void Flag()
        {
            //do nothing
        }
    }
}
