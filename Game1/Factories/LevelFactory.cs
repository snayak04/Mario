using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class LevelFactory
    {
        private static LevelFactory instance = new LevelFactory();
        public static LevelFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private LevelFactory() { }
        public Texture2D castle;
        public Texture2D logo;
        public Texture2D marioLogo;
         public void LoadAllTextures(ContentManager content)
         {
            castle = content.Load<Texture2D>("castle");
            logo = content.Load<Texture2D>("logo");
            marioLogo = content.Load<Texture2D>("smb");
        }
        public List<Texture2D> GetMenuItems()
        {
            List<Texture2D> list = new List<Texture2D>();
            list.Add(logo);
            list.Add(marioLogo);
            return list;
        }
        public Castle CreateCastle(Vector2 pos)
        {
            return new Castle(castle, pos);
        }

    }
}
