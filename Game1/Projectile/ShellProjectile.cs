using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class ShellProjectile : IProjectile
    {
        public Rectangle Position { get; set; }
        public Vector2 Location { get; set; }
        public Physics Movement { get; set; }
        public bool IsVisible { get; set; }
        public bool isShotRight { get; set; }
        public int ShellCount { get; set; }

        const int MAXTIME = 100;
        const int MAXFIREBALLCYCLECOUNT = 3;

        private int Rows = 1;
        private int Columns = 1;
        private int currentFrame = 0;
        private int delay = 0;

        private Vector2 posChange;
        private Vector2 move;

        public Texture2D Texture;

        public ShellProjectile(Texture2D texture, Vector2 pos)
        {
            ShellCount = 0;
            Texture = texture;
            Location = pos;
            posChange = new Vector2(0, 0);
            delay = 0;
            IsVisible = true;
            //isDead = false;
        }
        public void BounceX(int width)
        {
            posChange.X += width;
        }

        public void BounceY(int height)
        {
            posChange.Y += height;
        }

        public void TurnX()
        {
            move.X = move.X * (-1);
        }

        public void TurnY()
        {
            move.Y = move.Y * (-1);
        }

        public void Update()
        {
            Location += posChange;
            posChange.X = 0;
            posChange.Y = 0;
            Location += move;
            Position = new Rectangle((int)Location.X, (int)Location.Y, Texture.Width / Columns, Texture.Height / Rows);
            delay++;
            if (delay == 10)
            {
                isShotRight = true;
                currentFrame++;
                if (currentFrame == 1)
                    currentFrame = 0;
                delay = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 pos)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            spriteBatch.Draw(Texture, Location, sourceRectangle, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }

        public void Move()
        {
            move = new Vector2(4, 0);
        }
        public void MoveLeft()
        {
            move = new Vector2(-4, 0);
        }

        public void Die()
        {
            IsVisible = false;
        }
    }
}

