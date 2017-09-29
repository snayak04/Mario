using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class FlyingEnemy
    {

        Texture2D Texture;
        Vector2 velocity;
        public Rectangle Position { get;set; }
        public Vector2 Location { get; set; }
        Random random = new Random();
        int randY, randX;
        public bool IsVisible { get; set; }
        private int rows = 1;
        private int columns = 2;
        private int currentFrame = 0;
        private int totalFrames = 2;
        int delay;
        public FlyingEnemy(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Location = position;
            randY = random.Next(-4, 6);
            randX = random.Next(5, 6);
            Position = new Rectangle((int)Location.X, (int)Location.Y, Texture.Width / columns, Texture.Height / rows);
            delay = 0;
            velocity = new Vector2(randX, randY);
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            int width = Texture.Width / columns;
            int height = Texture.Height / rows;
            int row = (int)((float)currentFrame / (float)columns);
            int column = currentFrame % columns;
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            spriteBatch.Draw(Texture, Location, sourceRectangle, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }



        public void Update(GraphicsDevice graphics)
        {
            
            Location += velocity;
            if (Location.Y <= 0 || Location.Y >= graphics.Viewport.Height-50)
                velocity.Y = -velocity.Y;
            delay++;
            if (delay == 10)
            {
                currentFrame++;
                if (currentFrame == totalFrames)
                    currentFrame = 0;
                delay = 0;
            }
            Position = new Rectangle((int)Location.X, (int)Location.Y, Texture.Width / columns, Texture.Height / rows);
        }

       
    }
}
