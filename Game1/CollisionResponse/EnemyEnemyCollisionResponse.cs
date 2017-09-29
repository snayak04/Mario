using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class EnemyEnemyCollisionResponse
    {
        public EnemyEnemyCollisionResponse(IEnemy e1, IEnemy e2, CollisionSide type)
        {
            Rectangle intersect = Rectangle.Intersect(e1.Position, e2.Position);

            if(type == CollisionSide.Left)
            {
                if ((!e1.IsDead) && (!e2.IsDead))
                {
                    e1.BounceX(intersect.Width);
                    e2.BounceX(-intersect.Width);
                    e1.Turn();
                    e2.Turn();
                }
            } else if (type == CollisionSide.Right)
            {
                if ((!e1.IsDead) && (!e2.IsDead))
                {
                    e1.BounceX(-intersect.Width);
                    e2.BounceX(intersect.Width);
                    e1.Turn();
                    e2.Turn();
                }
            }
        }
    }
}
