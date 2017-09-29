using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game1
{
    public interface ITextureAtlas
    {
        int Height { get; }
        int Width { get; }
        void Draw(SpriteBatch spriteBatch, Vector2 pos);
        void Update();
        void Update(bool falling);
    }
}
