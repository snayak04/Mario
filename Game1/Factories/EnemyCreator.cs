  using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class EnemyCreator
    {
        public static Vector2 currPosition { get; set; }
        public static List<IEnemy> LoadEnemy()
        {
            List<IEnemy> enemyList = new List<IEnemy>();
            List<String[]> loading = LevelLoader.ReturnLevel();

            int x = 0, y = 0;
            foreach(String[] row in loading)
            {
                foreach (String column in row)
                {
                    IEnemy enemy = null;

                    switch (column)
                    {
                        case "goomba":
                            currPosition = new Vector2(x * ItemFactory.Instance.brickBlock.Width, (y+1 ) * ItemFactory.Instance.brickBlock.Height - EnemyFactory.Instance.goomba.Height);
                            enemy = EnemyFactory.Instance.CreateGoomba(currPosition);
                            break;
                        case "turtle":
                            currPosition = new Vector2(x * ItemFactory.Instance.brickBlock.Width, (y+1 ) * ItemFactory.Instance.brickBlock.Height - EnemyFactory.Instance.turtle.Height);
                            enemy = EnemyFactory.Instance.CreateTurtle(currPosition);
                            break;
                        case "ht":
                            currPosition = currPosition = new Vector2(x * ItemFactory.Instance.brickBlock.Width, (y + 1) * ItemFactory.Instance.brickBlock.Height - EnemyFactory.Instance.turtle.Height);
                            enemy = EnemyFactory.Instance.CreateHiddenLevelTurtle(currPosition);
                            break;
                        case "hg":
                            currPosition = new Vector2(x * ItemFactory.Instance.brickBlock.Width, (y + 1) * ItemFactory.Instance.brickBlock.Height - EnemyFactory.Instance.goomba.Height);
                            enemy = EnemyFactory.Instance.CreateHiddenLevelTurtle(currPosition);
                            break;
                        default:
                            break;
                    }
                    if (enemy != null)
                    {
                        enemyList.Add(enemy);
                    }

                    x++;
                }
                x = 0;
                y++;
            }
            return enemyList;

        }
    }
}
