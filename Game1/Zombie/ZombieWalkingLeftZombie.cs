using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class ZombieWalkingLeftZombie : IZombie
    {
        public Vector2 Location { get; set; }
        public Rectangle Position { get; set; }
        public Texture2D Texture { get; set; }
        public ITextureAtlas TextureAtlas { get; set; }
        public int SpawnTimer { get; set; }
        private int Rows = 1;
        private int Columns = 3;
        private int currentFrame = 0;
        //private int delay = 0;
        private Vector2 posChange;
        private Vector2 move;
        private Vector2 locale;
        private int startTime = 1200;
        public bool Multiplier { get; set; }
        public ZombieWalkingLeftZombie(ITextureAtlas txt, Vector2 pos)
        {
            Multiplier = false;
            TextureAtlas = txt;
            Location = pos;
            posChange = new Vector2(0, 0);
            move = new Vector2(-1, 0);
            Position = new Rectangle((int)Location.X, (int)Location.Y, TextureAtlas.Width, TextureAtlas.Height);
            SpawnTimer = startTime;
        }

        public void Update()
        {
            SpawnTimer--;
            Location += posChange;
            posChange.X = 0;
            posChange.Y = 0;
            TextureAtlas.Update();
            Location += move;
            Position = new Rectangle((int)Location.X, (int)Location.Y, TextureAtlas.Width, TextureAtlas.Height);
            if (SpawnTimer == 0)
                SpawnTimer = startTime;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            locale.Y = Location.Y + TextureAtlas.Height;
            locale.X = Location.X;
            TextureAtlas.Draw(spriteBatch, locale);
        }
        public void BounceX(int width)
        {
            posChange.X = width;
        }
        public void BounceY(int height)
        {
            posChange.Y = height;
        }
        public void Fall()
        {
            move.Y = 3;
        }
        public void Land()
        {
            move.Y = 0;
        }
    }
}
