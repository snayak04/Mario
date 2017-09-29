using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public interface IZombie
    {

        Vector2 Location { get; set; }
        Rectangle Position { get; }
        Texture2D Texture { get; set; }
        ITextureAtlas TextureAtlas { get; set; }
        int SpawnTimer { get; set; }
        void Update();
        void Draw(SpriteBatch spriteBatch);
        bool Multiplier { get; set; }
        void BounceX(int width);
        void BounceY(int height);        
        void Fall();
        void Land();
    }
}
