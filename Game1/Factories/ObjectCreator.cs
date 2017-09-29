using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class ObjectCreator
    {
        public static Vector2 currPosition { get; set; }

        public static List<IObject> LoadObject()
        {
            List<IObject> objList = new List<IObject>();
            List<String[]> loading = LevelLoader.ReturnLevel();


            int x = 0, y = 0;
            foreach (String[] row in loading)
            {

                foreach (String column in row)
                {
                    IObject obj = null;
                    currPosition = new Vector2(x * ItemFactory.Instance.brickBlock.Width, y * ItemFactory.Instance.brickBlock.Height);

                    switch (column)
                    {
                        case "flower":
                            obj = ObjectFactory.Instance.CreateFlower(currPosition);
                            break;
                        case "star":
                            obj = ObjectFactory.Instance.CreateStar(currPosition);
                            break;
                        case "coin":
                            obj = ObjectFactory.Instance.CreateCoin(currPosition);
                            break;
                        case "redmushroom":
                            obj = ObjectFactory.Instance.CreateRedMushroom(currPosition);
                            break;
                        case "greenmushroom":
                            obj = ObjectFactory.Instance.CreateGreenMushroom(currPosition);
                            break;
                       
                        default:
                            break;
                    }

                    if (obj != null)
                    {
                        objList.Add(obj);
                    }
                    x++;
                }

                x = 0;
                y++;
            }

            return objList;
        }
    }
}
