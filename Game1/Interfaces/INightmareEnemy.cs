using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public interface INightmareEnemy
    {
        Rectangle Position { get; set; }
        Vector2 Location { get; set; }
        ITextureAtlas Texture { get; set; }
        void Update();
        void Draw(SpriteBatch spriteBatch);
        bool IsVisible { get; set; }
        bool IsKilled { get; set; }

        void Infect();
        void Delay();
        void Die();
        void Land();
        void Turn();
        void TurnLeft();
        void TurnRight();
        void Fall();
        void BounceX(int width);
        void BounceY(int height);


    }
}
