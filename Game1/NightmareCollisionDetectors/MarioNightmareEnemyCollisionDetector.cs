using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class MarioNightmareEnemyCollisionDetector
    {
        public MarioNightmareEnemyCollisionDetector(Game1 g, INightmareEnemy n)
        {
            Rectangle mario = g.Character.Position;
            Rectangle nm = n.Position;

            CollisionSide type = CollisionDetector.Detect(mario, nm);
                if (type != CollisionSide.None)
                {
                    new MarioNighmareEnemyCollisionResponsecs(g.Character, n, type, g);
                }
        }
        public MarioNightmareEnemyCollisionDetector(Game1 g, FlyingEnemy n)
        {
            Rectangle mario = g.Character.Position;
            Rectangle nm = new Rectangle((int)n.Position.X,(int) n.Position.Y, EnemyFactory.Instance.flyingEnemy.Height, EnemyFactory.Instance.flyingEnemy.Width/2);

            CollisionSide type = CollisionDetector.Detect(mario, nm);


            if (type != CollisionSide.None)
            {
                new MarioNighmareEnemyCollisionResponsecs(g.Character, n, type, g);
            }

        }
    }
}
