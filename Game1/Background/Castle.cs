using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class Castle
    {
        public Texture2D Texture;
        public Vector2 Position;
        public Castle(Texture2D texture, Vector2 pos)
        {
            Texture = texture;
            Position = pos;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}
