using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;
/*
 *This class will read the file, which is loaded in Item Manager, and call the Draw method for various IItems 
 *
 */
namespace Game1
{
    public class LevelLoader
    {
        private static List<String[]> map;
        private static LevelLoader instance = new LevelLoader();

        public static LevelLoader Instance
        {
            get
            {
                return instance;
            }
        }
        private LevelLoader()
        {
            map = new List<String[]>();
        }

        public List<String[]> loadLevel(String file)
        {
            map = new List<string[]>();
            using (StreamReader reader = new StreamReader(file))
            {
                String line = null;
                while ((line = reader.ReadLine()) != null)
                {
                    map.Add(line.Split(','));

                }
            }
            return map;
        }
        public static List<String[]> ReturnLevel()
        {
            return map;
        }
    }
}
