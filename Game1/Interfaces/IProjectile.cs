using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public interface IProjectile
    {
        Rectangle Position { get; set; }
        Vector2 Location { get; set; }
        Physics Movement { get; set; }
        bool IsVisible { get; set; }
        bool isShotRight { get; set; }
        void BounceX(int width);
        void BounceY(int height);
        void TurnX();
        void TurnY();
        int ShellCount { get; set; }
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 pos);
        void Move();
        void MoveLeft();
        void Die();
    }
}
