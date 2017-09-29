using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class ProjectileCollisionDetector : ICollisionDetector
    {
        private Game1 g;

        private List<IProjectile> projectiles;
        private List<IEnemy> enemies;
        private List<IItems> items;

        public ProjectileCollisionDetector(Game1 game)
        {
            g = game;
        }
        public ProjectileCollisionDetector(List<IProjectile> projectiles, List<IEnemy> enemies, List<IItems> items, IMario mario, Game1 game)
        {
            this.projectiles = projectiles;
            this.enemies = enemies;
            this.items = items;
            g = game;
        }

        public void Update()
        {
            ProjectileItemCollision();
            ProjectileEnemyCollision();
        
            ProjectileMarioCollision();
            ProjectileProjectileCollision();
        }

        private void ProjectileItemCollision()
        {
            foreach (IProjectile p in projectiles)
            {
                IItems largestItem = null;
                int largestArea = 0;
                CollisionSide largestSide = CollisionSide.None;

                foreach (IItems i in items)
                {
                    Rectangle projectile = p.Position;
                    Rectangle item = i.Position;
                    CollisionSide collisionType = CollisionDetector.Detect(projectile, item);
                    if (collisionType != CollisionSide.None)
                    {
                        if (largestItem == null)
                        {
                            largestItem = i;
                            Rectangle tempRect = Rectangle.Intersect(projectile, item);
                            largestArea = tempRect.Width * tempRect.Height;
                            largestSide = collisionType;
                        }
                        else
                        {
                            Rectangle testIntersection = Rectangle.Intersect(projectile, item);
                            if ((largestArea) < (testIntersection.Width * testIntersection.Height))
                            {
                                largestArea = testIntersection.Width * testIntersection.Height;
                                largestItem = i;
                                largestSide = collisionType;
                            }
                        }
                    }
                }
                if (largestItem != null)
                {
                    new ProjectileItemCollisionResponse(p, largestItem, largestSide, items);
                }
            }
        }

        private void ProjectileEnemyCollision()
        {
            foreach (IProjectile p in projectiles)
            {
                foreach (IEnemy e in enemies)
                {
                    Rectangle fireball = p.Position;
                    Rectangle enemy = e.Position;
                    CollisionSide collisionType = CollisionDetector.Detect(fireball, enemy);
                    if (collisionType != CollisionSide.None)
                    {
                        new ProjectileEnemyCollsionResponse(p, e, collisionType, g.Character);
                    }
                }
            }
        }

        private void ProjectileMarioCollision()
        {
            Rectangle mario = g.Character.Position;
            for (int i = 0; i < projectiles.Count; i++)
            {
                IProjectile p = projectiles[i];
                Rectangle proj = p.Position;
                CollisionSide type = CollisionDetector.Detect(proj, mario);
                if (type != CollisionSide.None)
                {
                    new ProjectileMarioCollisionResponse(g.Character, p, type);
                }
            }
        }

        private void ProjectileProjectileCollision()
        {
            for (int i = 0; i < projectiles.Count - 1; i++)
            {
                IProjectile p1 = projectiles[i];
                Rectangle proj1 = p1.Position;
                for (int j = i; j < projectiles.Count; j++)
                {
                    IProjectile p2 = projectiles[j];

                    Rectangle proj2 = p2.Position;
                    CollisionSide type = CollisionDetector.Detect(proj1, proj2);
                    if (type != CollisionSide.None)
                    {
                        new ProjectileProjectileCollisionResponse(p1, p2, type);
                    }
                }


            }
        }

    }
}
