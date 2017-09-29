using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class MarioEnemyCollisionResponse
    {
        public MarioEnemyCollisionResponse(IMario m, IEnemy e, CollisionSide c, List<IEnemy> enemies, List<IProjectile> projectiles, Game1 g)
        {
            if (c == CollisionSide.Top)
            {
                if (e is TurtleEnemy)
                {
                    m.Bounce();
                    Console.WriteLine("Adding Shell");
                     projectiles.Add(ProjectileFactory.Instance.CreateShell(new Microsoft.Xna.Framework.Vector2(e.Location.X, e.Location.Y+49)));                
                }
                else
                {
                    e.Stomped();
                    m.Bounce();
                }
                SoundEffectFactory.Instance.CreateEnemyStompSound().PlaySound();
                m.consecutiveCrash = true;
                m.SmashEnemy();
                enemies.Remove(e);
                //m.Bounce();
            }
            else
            {
                if (!m.Invincible)
                { 
                    g.Character.Die();
                }
                else if (m.Invincible)
                {
                    SoundEffectFactory.Instance.CreateProjectileHitSound().PlaySound();
                    enemies.Remove(e);

                }
            }
        }
    }
}
