using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public interface IEnemy
    {
        Vector2 Location { get; set; }
        Rectangle Position { get; }
        Texture2D Texture { get; set; }
        bool IsStomped { get; set; }
        bool IsDead { get; set; }
        bool IsKilled { get; set; }
        int Collision { get; set; }
        void Update();
        void Draw(SpriteBatch spriteBatch);
        void BounceX(int width);
        void BounceY(int height);
        void Turn();
        void Stomped();
        void Dead();
        void Fall();
        void Land();
        void KilledRight();
        void KilledLeft();

        void Shell(Game1 g);
        void bounceDead();
    }
}
