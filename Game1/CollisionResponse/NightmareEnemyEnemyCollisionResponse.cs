using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class NightmareEnemyEnemyCollisionResponse
    {
        public NightmareEnemyEnemyCollisionResponse(INightmareEnemy e1, INightmareEnemy e2, CollisionSide type)
        {
            Rectangle intersect = Rectangle.Intersect(e1.Position, e2.Position);

            if (type == CollisionSide.Left)
            {

                e1.BounceX(intersect.Width);
                e2.BounceX(-intersect.Width);
                e1.Turn();
                e2.Turn();

            }
            else if (type == CollisionSide.Right)
            {

                e1.BounceX(-intersect.Width);
                e2.BounceX(intersect.Width);
                e1.Turn();
                e2.Turn();

            }
        }
    }
}
