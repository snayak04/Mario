using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Collections;

namespace Game1
{
    public class NightmareMarioCollisionDetector : ICollisionDetector
    {
        private Game1 g;
        private List<FlyingEnemy> flyingEnemy;
        private List<INightmareEnemy> nightmareEnemyList;
        private List<IObject> objects;
        private List<IItems> items;
        private List<IZombie> nightmareZombie;

        public NightmareMarioCollisionDetector(IMario mario, List<IItems> items, List<INightmareEnemy> enemies, List<IObject> objects, List<FlyingEnemy> flyingEnemy, List<IZombie> zombies, Game1 game)
        {
            this.items = items;
            
            this.nightmareEnemyList = enemies;
            this.objects = objects;
            this.flyingEnemy = flyingEnemy;
            this.nightmareZombie = zombies;
            this.g = game;
        }

        public void Update()
        {
            MarioItemCollision();
            MarioObjectCollision();
            MarioNightmareEnemyCollision();
            MarioFlyingEnemyCollision();
            MarioZombieCollision();
        }

        private void MarioZombieCollision()
        {
            for(int i = 0; i < nightmareZombie.Count; i++)
            {
                IZombie z = nightmareZombie[i];
                Rectangle zombie = z.Position;
                Rectangle m = g.Character.Position;

                CollisionSide cs = CollisionDetector.Detect(m, zombie);

                if(cs != CollisionSide.None)
                {
                    new ZombieMarioCollisionResponse(z, g.Character, cs, g);
                }
            }
        }
        
        private void MarioFlyingEnemyCollision()
        {
            for(int i = 0; i < flyingEnemy.Count; i++)
            {
                FlyingEnemy fe = flyingEnemy[i];
                Rectangle enemy = fe.Position;
                Rectangle m = g.Character.Position;

                CollisionSide cs = CollisionDetector.Detect(m, enemy);

                if(cs != CollisionSide.None)
                {
                    new MarioNightmareEnemyCollisionResponse(g.Character, fe, cs, g);
                }
            }
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

        private void MarioNightmareEnemyCollision()
        {
            for(int i = 0; i < nightmareEnemyList.Count; i++)
            {
                INightmareEnemy e = nightmareEnemyList[i];

                if(!e.IsKilled)
                {
                    Rectangle mario = g.Character.Position;
                    Rectangle enemy = e.Position;

                    CollisionSide type = CollisionDetector.Detect(mario, enemy);

                    if(type != CollisionSide.None)
                    {
                        new MarioNightmareEnemyCollisionResponse(g.Character, e, nightmareZombie, type, g);
                    }
                }
            }
        }

       
    }
}
