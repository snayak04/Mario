using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class ObjectCollisionDetector : ICollisionDetector
    {
        private Game1 g;
        private List<IObject> objects;
        private List<IItems> items;

        public ObjectCollisionDetector(Game1 game)
        {
            g = game;
        }
        public ObjectCollisionDetector(List<IObject> objects, List<IItems> items)
        {
            this.objects = objects;
            this.items = items;
        }
        public void Update()
        {
            ObjectItemCollision();
        }

        private void ObjectItemCollision()
        {
            foreach (IObject o in objects)
            {
                Rectangle obj = o.Position;
                bool isFallingObject = true;
                foreach (IItems i in items)
                {
                    Rectangle item = i.Position;
                    CollisionSide type = CollisionDetector.Detect(obj, item);
                    if (type != CollisionSide.None)
                    {
                        new ObjectItemCollisionResponse(o, i, type);
                    }
                    Rectangle copy = obj;
                    copy.Offset(0, 1);
                    CollisionSide bound = CollisionDetector.Detect(copy, item);
                    if (bound == CollisionSide.Top)
                    {
                        isFallingObject = false;
                    }
                }
                if (isFallingObject)
                {
                    o.Fall();
                }
                else
                {
                    o.Land();
                }
            }
        }
    }
}
