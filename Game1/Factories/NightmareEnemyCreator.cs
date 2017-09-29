using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class NightmareEnemyCreator
    {
        public static Vector2 currPosition { get; set; }
        public static List<INightmareEnemy> LoadEnemy()
        {
            List<INightmareEnemy> nightmareEnemyList = new List<INightmareEnemy>();
            List<String[]> loading = LevelLoader.ReturnLevel();

            int x = 0, y = 0;
            foreach (String[] row in loading)
            {
                foreach (String column in row)
                {
                    INightmareEnemy enemy = null;

                    switch (column)
                    {
                        case "nGoomba":
                            currPosition = new Vector2(x * ItemFactory.Instance.brickBlock.Width, (y + 1) * ItemFactory.Instance.brickBlock.Height - EnemyFactory.Instance.goomba.Height);
                            enemy = NightmareEnemyFactory.Instance.CreateNightmareGoomba(currPosition);
                            break;
                        case "nTurtle":
                            currPosition = new Vector2(x * ItemFactory.Instance.brickBlock.Width, (y +1) * ItemFactory.Instance.brickBlock.Height - NightmareEnemyFactory.Instance.nightmareKoopa.Height);
                            Console.WriteLine((y + 1) * ItemFactory.Instance.brickBlock.Height - NightmareEnemyFactory.Instance.nightmareKoopa.Height);
                            enemy = NightmareEnemyFactory.Instance.CreateNightmareTurtle(currPosition);

                            break;
                        default:
                            break;
                    }
                    if (enemy != null)
                    {
                        nightmareEnemyList.Add(enemy);
                    }

                    x++;
                }
                x = 0;
                y++;
            }
            return nightmareEnemyList;
        }
    }
}
