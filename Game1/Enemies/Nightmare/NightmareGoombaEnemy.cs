using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class NightmareGoombaEnemy : INightmareEnemy
    {

        public ITextureAtlas Texture { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle Position { get; set; }
        public bool IsVisible { get; set; }
        // dupulicated name: Texture
        
        public bool IsKilled { get; set; }

        private int delay;
        private Vector2 posChange;
        private Vector2 move;
        private bool delayFlag;

        public NightmareGoombaEnemy(ITextureAtlas txt, Vector2 position)
        {
            IsKilled = false;
            Texture = txt;

            Location = position;
            
            delay = 60;
            delayFlag = false;
            posChange = new Vector2(0, 0);
            Position = new Rectangle((int)position.X, (int)position.Y, Texture.Width, Texture.Height);
            move = new Vector2(-1, 0);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            int width = Texture.Width;
            int height = Texture.Height;
            Vector2 draw = new Vector2(Location.X, Location.Y + Texture.Height);
            Texture.Draw(spriteBatch, draw);
        }
        public void Update()
        {
            Location += posChange;
            posChange.X = 0;
            posChange.Y = 0;
            Texture.Update();
            Location += move;
            Position = new Rectangle((int)Location.X, (int)Location.Y, Texture.Width, Texture.Height);
        }
        public void Infect()
        {
            int delayFactor = 60;
            if (delayFlag)
            {
                delayFactor = 0;
                delayFlag = false;
            }

            if (delayFactor != delay)
            {
                delayFactor++;
            }

            if (delayFactor == delay)
            {
                // TODO: infect
            }
        }
        public void Turn()
        {
            move.X = move.X * (-1);
        }
        public void TurnLeft()
        {
            if (move.X > 0)
            {
                move.X *= (-1);
            }
        }

        public void TurnRight()
        {
            if (move.X < 0)
            {
                move.X *= (-1);
            }
        }

        public void Fall()
        {
            move.Y = 3;
        }
        public void Land()
        {
            move.Y = 0;
        }

        public void Die()
        {
            IsKilled = true;
        }

        public void BounceX(int width)
        {
            posChange.X = width;
        }

        public void BounceY(int height)
        {
            posChange.Y += height;
        }

        public void Delay()
        {
            delayFlag = true;
        }
    }
}
