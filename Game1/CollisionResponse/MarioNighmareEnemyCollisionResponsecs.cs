using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class MarioNightmareEnemyCollisionResponse
    {
        private double timer =1;
        private Vector2 locale;
        private double delayTimer;
        public MarioNightmareEnemyCollisionResponse(IMario m, INightmareEnemy n, List<IZombie> zombies, CollisionSide c, Game1 g)
        {
            timer--;  // = g.TargetElapsedTime.TotalSeconds;
            delayTimer = timer + 2;
            
            if (c == CollisionSide.Top)
            {
                if (!g.nightmareThemeIsStarted)
                {
                    MediaPlayer.Play(g.nightmareTheme);
                    g.nightmareThemeIsStarted = true;
                }
                m.Bounce();
                n.Die();
                if (timer == 0)
                {   
                        locale.X = n.Location.X;
                        locale.Y = n.Location.Y+ n.Texture.Height;
                        SoundEffectFactory.Instance.CreateNightmareZombieSpawnSound().PlaySound();
                        zombies.Add(ZombieFactory.Instance.CreateZombie(locale));
                        timer = 1;
                        n.Die();
                }
            }
            else
            {
               m.Die();
            }
            
        }
        public MarioNightmareEnemyCollisionResponse(IMario m, FlyingEnemy n, CollisionSide c, Game1 g)
        {

            if (c == CollisionSide.None)
            {
                //Do nothing. 
            }
            else
            {
                m.Die();
            }

        }
    }
}
