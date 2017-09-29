using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class ZombieMarioCollisionResponse
    {
        public ZombieMarioCollisionResponse(IZombie z, IMario m, CollisionSide c, Game1 g)
        {
                g.Character.Die();            
        }
    }
}
