  using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class BackgroundCreator
    {
        public static Vector2 currPosition { get; set; }
        public static Vector2 LoadCastle()
        {
            List<String[]> loading = LevelLoader.ReturnLevel();

            int x = 0, y = 0;
            foreach(String[] row in loading)
            {
                foreach (String column in row)
                {
                    switch (column)
                    {
                        case "castle":
                            currPosition = new Vector2(x * ItemFactory.Instance.brickBlock.Width, (y+1 ) * ItemFactory.Instance.rockBlock.Height-LevelFactory.Instance.castle.Height);
                            break;
                        default:
                            break;
                    }
                    x++;
                }
                x = 0;
                y++;
            }
            return currPosition;

        }
    }
}
