using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Collections;

namespace Game1
{
    public class MarioCollisionDetector : ICollisionDetector
    {
        private Game1 g;
        private List<IItems> items;
        private List<IEnemy> enemies;
        private List<IObject> objects;
        private List<IProjectile> projectiles;

        public MarioCollisionDetector(IMario mario, List<IItems> items, List<IEnemy> enemies, List<IObject> objects, List<IProjectile>projectiles, Game1 game)
        {
            this.items = items;
            this.enemies = enemies;
            this.objects = objects;
            this.projectiles = projectiles;
            this.g = game;
        }

        public void Update()
        {
            MarioItemCollision();
            MarioObjectCollision();
            MarioEnemyCollision();
        }
        
        private void MarioItemCollision()
        {
            IItems largestItem = null;
            int largestArea = 0;
            CollisionSide largestCollision = CollisionSide.None;
            bool isFalling = true;

            for (int i = 0; i < items.Count; i++)
            {
                IItems item = items[i];

                Rectangle block = item.Position;
                Rectangle mario = g.Character.Position;
                CollisionSide type = CollisionDetector.Detect(mario, block);
                if (type != CollisionSide.None)
                {
                    if (largestItem == null)
                    {
                        Rectangle intersectRect = Rectangle.Intersect(mario, block);
                        largestItem = item;
                        largestArea = intersectRect.Width * intersectRect.Height;
                        largestCollision = type;
                    }
                    else
                    {
                        Rectangle testRect = Rectangle.Intersect(mario, block);

                        if (largestArea < (testRect.Width * testRect.Height))
                        {
                            largestItem = item;
                            largestArea = testRect.Width * testRect.Height;
                            largestCollision = type;
                        }
                    }


                }

                mario.Offset(0, 1);
                CollisionSide bound = CollisionDetector.Detect(mario, block);

                if (bound == CollisionSide.Top)
                {
                    isFalling = false;
                    if (item is TransitionPipeItem && g.Character.Movement.IsCrouching)
                    {
                        g.CurrentState = new HiddenLevelState(g, g.CurrentState, items);
                    }
                }
            }

            if (largestItem != null)
            {
                new MarioItemCollisionResponse(g.Character, largestItem, largestCollision, items, objects, g);
            }

            if (isFalling)
            {
                g.Character.Movement.Fall();
            }
        }

        private void MarioObjectCollision()
        {
            foreach(IObject obj in objects)
            {
                Rectangle objectRectangle = obj.Position;
                Rectangle marioRectangle = g.Character.Position;

                if(marioRectangle.Intersects(objectRectangle))
                {
                    new MarioObjectCollisionResponse(g, obj);
                }
            }
        }

        private void MarioEnemyCollision()
        {
            for(int i = 0; i < enemies.Count; i++)
            {
                IEnemy e = enemies[i];

                if(!e.IsKilled)
                {
                    Rectangle mario = g.Character.Position;
                    Rectangle enemy = e.Position;

                    CollisionSide type = CollisionDetector.Detect(mario, enemy);

                    if(type != CollisionSide.None)
                    {
                        new MarioEnemyCollisionResponse(g.Character, e, type, enemies, projectiles, g);
                        Console.WriteLine(projectiles.Count);
                    }
                }
            }
        }
    }
}
