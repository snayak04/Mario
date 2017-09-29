using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class ProjectileEnemyCollsionResponse
    {
        public ProjectileEnemyCollsionResponse(IProjectile p, IEnemy e, CollisionSide cs, IMario m)
        {
            if((cs == CollisionSide.Top) || (cs == CollisionSide.Right))
            {
                p.IsVisible = false;
                e.KilledRight();
                /*if (p is FireballProjectile)
                {
                    e.KilledRight();
                }
                else
                { 
                   e.KilledRight();
                }
               */
            }
            else
            {
                p.IsVisible = false;
                e.KilledLeft();
               /* if (p is FireballProjectile)
                {
                    e.KilledLeft();
                }
                else
                {
                    e.KilledLeft();
                }*/
            }
            if (e.Collision == 1)
            {
                m.ProjectileSmash();
                SoundEffectFactory.Instance.CreateProjectileHitSound().PlaySound();
            }
        }
    }
}
