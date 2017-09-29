using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class ZombieWalkingRightZombie : IZombie
    {
        public Vector2 Location { get; set; }
        public Rectangle Position { get; set; }
        public Texture2D Texture { get; set; }
        public ITextureAtlas TextureAtlas { get; set; }
        public int SpawnTimer { get; set; }
        private Vector2 posChange;
        private Vector2 move;
        private Vector2 locale;
        private int startTime = 10;
        private int appearenceDelay = 50;
        private int appearenceTimer;
        private int bufferRate = 5;
        private int buffer = 0;
        public bool Multiplier { get; set; }
        //private Boolean brickMarioCollision;
        public ZombieWalkingRightZombie(ITextureAtlas txt, Vector2 pos)
        {
            Multiplier = false;
            TextureAtlas = txt;
            locale.X = pos.X;
            locale.Y = pos.Y - txt.Height;
            Location = locale;
            posChange = new Vector2(0, 0);
            appearenceTimer = 0;
            move = new Vector2(3, 0);
            SpawnTimer = startTime;
            Position = new Rectangle(0, 0, 0, 0);
        }
        public void Update()
        {
            if (appearenceTimer > appearenceDelay)
            {
                Position = new Rectangle((int)locale.X, (int)locale.Y, TextureAtlas.Width, TextureAtlas.Height);
                SpawnTimer--;
                Location += posChange;
                posChange.X = 0;
                posChange.Y = 0;
                TextureAtlas.Update();
                if (buffer == bufferRate)
                {
                    Location += move;
                    buffer = 0;
                }
                buffer++;
                Position = new Rectangle((int)Location.X, (int)Location.Y, TextureAtlas.Width, TextureAtlas.Height);
                if (SpawnTimer == 0)
                    SpawnTimer = startTime;
            } else
            {
                appearenceTimer++;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 draw = new Vector2(Location.X, Location.Y + TextureAtlas.Height);
            if(appearenceTimer > appearenceDelay)
                TextureAtlas.Draw(spriteBatch, draw);

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
