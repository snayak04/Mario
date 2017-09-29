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
    public class NightmareEnemyFactory
    {
        public Texture2D nightmareKoopa;
        public static ITextureAtlas nightmareGoombaAtlas;
        public static ITextureAtlas nightmareLeftTurtleAtlas;
        public static ITextureAtlas nightmareRightTurtleAtlas;
        //public Texture2D zombie;

        private static NightmareEnemyFactory instance = new NightmareEnemyFactory();

        public static NightmareEnemyFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private NightmareEnemyFactory() { }

        public void LoadAllTextures(ContentManager content)
        {
            nightmareKoopa = content.Load<Texture2D>("rightNightmareKoopa");
            nightmareGoombaAtlas = new NightmareThreeFrameTextureAtlas(content.Load<Texture2D>("goomba"));
            nightmareLeftTurtleAtlas = new TwoFrameTextureAtlas(content.Load<Texture2D>("rightNightmareKoopa"));
            nightmareRightTurtleAtlas = new TwoFrameTextureAtlas(content.Load<Texture2D>("leftNightmareKoopa"));
        }

        public INightmareEnemy CreateNightmareGoomba(Vector2 pos)
        {
            return new NightmareGoombaEnemy(nightmareGoombaAtlas, pos);
        }
        public INightmareEnemy CreateNightmareTurtle(Vector2 pos)
        {
            return new NightmareTurtleEnemy(nightmareLeftTurtleAtlas, nightmareRightTurtleAtlas, pos);
        }
    }
}