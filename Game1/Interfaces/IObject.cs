using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game1
{
    public interface IObject
    {
        Rectangle Position { get; set; }    
        Vector2 Location { get; set; }      
       
        void Update();
        void Draw(SpriteBatch spriteBatch);
        bool IsUsed { get; set; }
        void BounceX(int width);
        void BounceY(int height);
        void Turn();
        void TurnY();
        void Fall();
        void Land();
    }
}
