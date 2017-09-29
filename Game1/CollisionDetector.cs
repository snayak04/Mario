using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public enum CollisionSide { Top, Left, Right, Bottom, None};
    public class CollisionDetector
    {
        private Game1 g;
        private ArrayList collisionDetectors;

        public CollisionDetector(IMario mario, List<IItems> items, List<IEnemy> enemies, List<IProjectile> projectiles, List<IObject> objects, Game1 g)
        {
            this.g = g;
            collisionDetectors = new ArrayList();
            collisionDetectors.Add(new MarioCollisionDetector(mario, items, enemies, objects, projectiles, g));
            collisionDetectors.Add(new ObjectCollisionDetector(objects, items));
            collisionDetectors.Add(new EnemyCollisionDetector(g, enemies, items));
            collisionDetectors.Add(new ProjectileCollisionDetector(projectiles, enemies, items, mario, g));
        }

        public static CollisionSide Detect(Rectangle marioRectangle, Rectangle otherEntityRectangle)
        {
            CollisionSide cs = CollisionSide.None;
            if(marioRectangle.Intersects(otherEntityRectangle))
            {
                Rectangle intersection = Rectangle.Intersect(marioRectangle, otherEntityRectangle);

                if(intersection.Width > intersection.Height)
                {
                    if(marioRectangle.Y < otherEntityRectangle.Y)
                    {
                        cs = CollisionSide.Top;
                    }
                    else
                    {
                        cs = CollisionSide.Bottom;
                    }
                }
                else
                {
                    if(marioRectangle.X < otherEntityRectangle.X)
                    {
                        cs = CollisionSide.Right;
                    }
                    else
                    {
                        cs = CollisionSide.Left;
                    }
                }
            }
            
            return cs;
        }

        public void MarioCastleCollision(Game1 g)
        {
            new MarioCastleCollisionResponse(g.Character, g.castle, g);
        }

        public void Update()
        {

            foreach(ICollisionDetector cd in collisionDetectors)
            {
                cd.Update();
            }
            if(!(g.CurrentState is NightmareGameState))
                MarioCastleCollision(g);
        }
    }
}
