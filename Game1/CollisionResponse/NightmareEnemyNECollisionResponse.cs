using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class NightmareEnemyNECollisionResponse
    {
        public NightmareEnemyNECollisionResponse(INightmareEnemy n1, INightmareEnemy n2, CollisionSide type, Game1 g)
        {
            Rectangle intersect = Rectangle.Intersect(n1.Position, n2.Position);
            if (type == CollisionSide.Left)
            {
                n1.BounceX(intersect.Width);
                n2.BounceX(-intersect.Width);
                n1.Turn();
                n2.Turn();
            }else if (type == CollisionSide.Right)
            {
                n1.BounceX(-intersect.Width);
                n2.BounceX(intersect.Width);
                n1.Turn();
                n2.Turn();
            }

        }
    }
}
