using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class EnemyCollisionDetector : ICollisionDetector
    {
        private Game1 g;
        private List<IEnemy> enemies;
        private List<IItems> items;

        public EnemyCollisionDetector(Game1 game)
        {
            g = game;
        }

        public EnemyCollisionDetector(Game1 game, List<IEnemy> enemies, List<IItems> items)
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

            foreach (IEnemy e in enemies)
            {
                fallingEnemies.Add(e);
            }

            for (int i = 0; i < items.Count; i++)
            {
                IItems I1 = items[i];
                I1.HasEnemyOnIt = false;
                Rectangle item = I1.Position;

                foreach (IEnemy e in enemies)
                {
                    Rectangle enemy = e.Position;

                    CollisionSide type = CollisionDetector.Detect(enemy, item);
                    if (type != CollisionSide.None && !e.IsKilled)
                    {
                        new EnemyItemCollisionResponse(e, I1, items, type, g);
                    }
                    Rectangle copy = enemy;
                    copy.Offset(0, 1);
                    CollisionSide bound = CollisionDetector.Detect(copy, item);

                    if (bound == CollisionSide.Top && !e.IsKilled)
                    {
                        if (fallingEnemies.Contains(e))
                        {
                            fallingEnemies.Remove(e);
                        }
                        I1.HasEnemyOnIt = true;
                    }
                }
            }

            foreach (IEnemy e in fallingEnemies)
            {
                e.Fall();
            }
        }
        private void EnemyEnemyCollision()
        {
            for (int i = 0; i < enemies.Count - 1; i++)
            {
                IEnemy e1 = enemies[i];
                if (!e1.IsKilled)
                {
                    Rectangle enemy1 = e1.Position;
                    for (int j = i; j < enemies.Count; j++)
                    {
                        IEnemy e2 = enemies[j];
                        if (!e2.IsKilled)
                        {
                            Rectangle enemy2 = e2.Position;
                            CollisionSide type = CollisionDetector.Detect(enemy1, enemy2);
                            if (type != CollisionSide.None)
                            {
                                new EnemyEnemyCollisionResponse(e1, e2, type);
                            }
                        }

                    }
                }

            }
        }
    }
}
