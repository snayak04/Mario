using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class ProjectileProjectileCollisionResponse
    {
        public ProjectileProjectileCollisionResponse(IProjectile p1, IProjectile p2, CollisionSide type)
        {
            if (p1 is FireballProjectile && p2 is ShellProjectile)
            {
                if (type != CollisionSide.None)
                {
                    p2.Die();

                }
            }
            if (p2 is FireballProjectile && p1 is ShellProjectile)
            {
                if (type != CollisionSide.None)
                {
                    p1.Die();
                }
            }
        }
    }
}
