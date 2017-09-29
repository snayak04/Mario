using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    
    public class NightmareCollisionDetector
    {
        private Game1 g;
        private ArrayList collisionDetectors;

        /*List<FlyingEnemy> flyingEnemy;
        List<INightmareEnemy> nightmareEnemyList;
        private List<IObject> objects;
        private List<IItems> items;
        private List<IZombie> nightmareZombie;*/

        public NightmareCollisionDetector(IMario mario, List<FlyingEnemy> flyingEnemy, List<INightmareEnemy> nightmareEnemies, List<IObject> objects, List<IItems> items, List<IZombie> zombies, Game1 g)
        {
            this.g = g;
            collisionDetectors = new ArrayList();
            collisionDetectors.Add(new NightmareMarioCollisionDetector(mario, items, nightmareEnemies, objects, flyingEnemy, zombies, g));
            collisionDetectors.Add(new NightmareZombieCollisionDetector(nightmareEnemies, zombies, g));
            collisionDetectors.Add(new NightmareEnemyCollisionDetector(g, nightmareEnemies, items));
        }

        public void Update()
        {

            foreach(ICollisionDetector cd in collisionDetectors)
            {
                cd.Update();
            }
        }
    }
}
