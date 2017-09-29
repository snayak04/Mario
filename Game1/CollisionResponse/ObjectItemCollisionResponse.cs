using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class ObjectItemCollisionResponse
    {
        public ObjectItemCollisionResponse(IObject o, IItems i, CollisionSide type)
        {
            Rectangle intersection = Rectangle.Intersect(o.Position, i.Position);
            if (o is StarObject)
            {
                switch (type)
                {
                    case CollisionSide.Top:
                        o.BounceY(-intersection.Height);
                        o.TurnY();
                        break;

                    case CollisionSide.Bottom:
                        o.BounceY(intersection.Height);
                        o.TurnY();
                        break;

                    case CollisionSide.Left:
                        o.BounceX(intersection.Width);
                        o.Turn();
                        break;

                    case CollisionSide.Right:
                        o.BounceX(-intersection.Width);
                        o.Turn();
                        break;
                }
            }
            else
            {
                switch (type)
                {
                    case CollisionSide.Top:
                        o.BounceY(-intersection.Height);
                        o.Land();
                        break;

                    case CollisionSide.Left:
                        o.BounceX(intersection.Width);
                        o.Turn();
                        break;
                    case CollisionSide.Right:
                        o.BounceX(-intersection.Width);
                        o.Turn();
                        break;
                }
            }
        }
    }
}
