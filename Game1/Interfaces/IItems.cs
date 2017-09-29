 using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public interface IItems
    {
        Rectangle Position { get; set; }
        Texture2D Texture { get; set; }
        Vector2 Location { get; set; }
        bool isBouncing { get; set; }
        bool isUsed { get; set; }
        bool HasEnemyOnIt { get; set; }
        bool timerStarted { get; set; }
        bool timerFinished { get; set; }
        int UsedOnce { get; set; }
        int yChange { get;  set; }
        void Bounce();
        //void Update();
        void Update(GameTime gt);
        void Draw(SpriteBatch spriteBatch);
        int Width { get; }
        int Height { get; }
        void Flag();
        int SoundCounter { get; set; }
    }
}
