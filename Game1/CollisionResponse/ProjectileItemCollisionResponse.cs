using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class ProjectileItemCollisionResponse
    {
        public ProjectileItemCollisionResponse(IProjectile p, IItems i, CollisionSide cs, List<IItems> items)
        {
            Rectangle intersection = Rectangle.Intersect(p.Position, i.Position);
            switch (cs)
            {
                case CollisionSide.Top:
                    p.BounceY(-intersection.Height*2);
                    p.TurnY();
                    break;
                case CollisionSide.Bottom:
                    p.BounceY(intersection.Height*2);
                    p.TurnY();                    
                    break;
                case CollisionSide.Left:
                    p.BounceX(intersection.Width*2);
                    p.TurnX();
                    break;
                case CollisionSide.Right:
                    p.BounceX(-intersection.Width*2);
                    p.TurnX();
                    break;
              
            }
        }
    }
}
