using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class ZombieNightmareEnemyCollisionResponse
    {
        private double timer = 1;
        private Vector2 locale;
        private double delayTimer;
        public ZombieNightmareEnemyCollisionResponse(IZombie z, INightmareEnemy n, List<IZombie> zombieList, CollisionSide c)
        {
            timer--;  // = g.TargetElapsedTime.TotalSeconds;
            delayTimer = timer + 2;
            locale = n.Location;
            if (c != CollisionSide.None)
            {
                if (n is NightmareGoombaEnemy)
                {
                    locale.Y = n.Location.Y + n.Texture.Height;
                    n.Die();
                    if (timer == 0)
                    {
                        SoundEffectFactory.Instance.CreateNightmareZombieSpawnSound().PlaySound();
                        zombieList.Add(ZombieFactory.Instance.CreateZombie(locale));
                        timer = 1;
                    }
                }
                else
                {
                    if (timer == 0)
                    {
                        n.Die();
                        SoundEffectFactory.Instance.CreateNightmareZombieSpawnSound().PlaySound();
                        zombieList.Add(ZombieFactory.Instance.CreateZombie(locale));
                        timer = 1;
                    }
                }
                
            }
        }   
    }
}
