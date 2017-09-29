using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Collections;

namespace Game1
{
    public class NightmareZombieCollisionDetector : ICollisionDetector
    {
        private Game1 g;
        private List<INightmareEnemy> nightmareEnemyList;
        private List<IZombie> zombies;

        public NightmareZombieCollisionDetector(List<INightmareEnemy> enemies, List<IZombie> zombies, Game1 game)
        {
            this.nightmareEnemyList = enemies;
            this.zombies = zombies;
            this.g = game;
        }

        public void Update()
        {
            ZombieEnemyCollisionDetect();
        }

        private void ZombieEnemyCollisionDetect()
        {
            for(int i = 0; i < zombies.Count; i++)
            {
                IZombie zombie = zombies[i];
                Rectangle z = zombie.Position;

                for(int j = 0; j < nightmareEnemyList.Count; j++)
                {
                    INightmareEnemy ne = nightmareEnemyList[j];
                    Rectangle n = ne.Position;

                    CollisionSide cs = CollisionDetector.Detect(z, n);

                    if(cs != CollisionSide.None)
                    {
                        new ZombieNightmareEnemyCollisionResponse(zombie, ne, zombies, cs);
                    }
                }
            }
        }

        
    }
}
