using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class ProjectileMarioCollisionResponse
    {
        public ProjectileMarioCollisionResponse(IMario m, IProjectile p, CollisionSide type)
        {
            Rectangle intersection = Rectangle.Intersect(m.Position, p.Position);
            Console.WriteLine("In the response");
            if (p is ShellProjectile)
            {
                if(p.ShellCount < 1) {
                    if (type == CollisionSide.Left || type == CollisionSide.Top)
                    {
                        m.BounceX(-intersection.Width);
                        m.BounceY(-intersection.Height);
                        p.Move();
                        p.ShellCount++;
                        Console.WriteLine("In the response block");

                    }
                    else if(type == CollisionSide.Right)
                    {
                        m.BounceX(intersection.Width);
                        p.MoveLeft();
                        p.ShellCount++;
                    }
                }
                else
                {
                    m.Die();
                }
            }
        }
    }
}
