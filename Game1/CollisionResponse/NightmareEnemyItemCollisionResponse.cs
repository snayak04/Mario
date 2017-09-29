using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class NightmareEnemyItemCollisionResponse
    {
        public NightmareEnemyItemCollisionResponse(INightmareEnemy n, IItems i, CollisionSide c, Game1 g)
        {
            Rectangle intersection = Rectangle.Intersect(n.Position, i.Position);
            switch (c)
            {
                case CollisionSide.Top:
                    n.BounceY(-intersection.Height);
                    if (!n.IsKilled)
                    {
                        n.Land();
                    }
                    break;
                case CollisionSide.Left:

                    n.TurnRight();
                    n.BounceX(intersection.Width);
                        
                    break;
                case CollisionSide.Right:
                    n.BounceX(-intersection.Width);
                    n.TurnLeft();
                    break;
                case CollisionSide.None:
                    n.Fall();
                    break;
            }
        }
    }
}
