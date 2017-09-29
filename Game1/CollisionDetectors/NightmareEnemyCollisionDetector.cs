using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class NightmareEnemyCollisionDetector : ICollisionDetector
    {
        private Game1 g;
        private List<INightmareEnemy> enemies;
        private List<IItems> items;

        public NightmareEnemyCollisionDetector(Game1 game, List<INightmareEnemy> enemies, List<IItems> items)
        {
            this.g = game;
            this.enemies = enemies;
            this.items = items;
        }
        public void Update()
        {
            EnemyItemCollision();
            EnemyEnemyCollision();
        }

        private void EnemyItemCollision()
        {
            ArrayList fallingEnemies = new ArrayList();

            foreach (INightmareEnemy e in enemies)
            {
                fallingEnemies.Add(e);
            }

            for (int i = 0; i < items.Count; i++)
            {
                IItems I1 = items[i];
                I1.HasEnemyOnIt = false;
                Rectangle item = I1.Position;

                foreach (INightmareEnemy e in enemies)
                {
                    Rectangle enemy = e.Position;
                    //enemy.Offset(0, -1);

                    CollisionSide type = CollisionDetector.Detect(enemy, item);
                    if (type != CollisionSide.None)
                    {
                        new NightmareEnemyItemCollisionResponse(e, I1, type, g);
                    }
                    Rectangle copy = enemy;
                    enemy.Offset(0, 3);
                    CollisionSide bound = CollisionDetector.Detect(enemy, item);

                    if (bound == CollisionSide.Top)
                    {
                        if (fallingEnemies.Contains(e))
                        {
                            fallingEnemies.Remove(e);
                        }
                        I1.HasEnemyOnIt = true;
                    }
                }
            }

            foreach (INightmareEnemy e in fallingEnemies)
            {
                e.Fall();
            }
        }
        private void EnemyEnemyCollision()
        {
            for (int i = 0; i < enemies.Count - 1; i++)
            {
                INightmareEnemy e1 = enemies[i];
                if (!e1.IsKilled)
                {
                    Rectangle enemy1 = e1.Position;
                    for (int j = i; j < enemies.Count; j++)
                    {
                        INightmareEnemy e2 = enemies[j];
                        if (!e2.IsKilled)
                        {
                            Rectangle enemy2 = e2.Position;
                            CollisionSide type = CollisionDetector.Detect(enemy1, enemy2);
                            if (type != CollisionSide.None)
                            {
                                new NightmareEnemyEnemyCollisionResponse(e1, e2, type);
                            }
                        }

                    }
                }

            }
        }
    }
}
