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
    public class EnemyFactory
    {
        public Texture2D goomba;
        public Texture2D turtle;
        public Texture2D hiddenLevelGoomba;
        public Texture2D hiddenLevelTurtle;
        public Texture2D flyingEnemy;
        private static EnemyFactory instance = new EnemyFactory();

        public static EnemyFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private EnemyFactory() { }

        public void LoadAllTextures(ContentManager content)
        {
            goomba = content.Load<Texture2D>("goomba");
            turtle = content.Load<Texture2D>("koopa");
            hiddenLevelGoomba = content.Load <Texture2D>("HiddenLevelGoomba");
            hiddenLevelTurtle = content.Load<Texture2D>("HiddenLevelKoopa");
            flyingEnemy = content.Load<Texture2D>("flyingEnemy");
        }

        public IEnemy CreateGoomba(Vector2 pos)
        {
            return new GoombaEnemy(goomba, pos);
        }

        public IEnemy CreateTurtle(Vector2 pos)
        {
            Vector2 offset = new Vector2(0,-1);
            return new TurtleEnemy(turtle, pos+offset);
        }

        public IEnemy CreateHiddenLevelTurtle(Vector2 pos)
        {
            Vector2 offset = new Vector2(0, -1);
            return new TurtleEnemy(hiddenLevelTurtle, offset);
        }

        public IEnemy CreateHiddenLevelGoomba(Vector2 pos)
        {
            Vector2 offset = new Vector2(0, -1);
            return new GoombaEnemy(hiddenLevelGoomba, offset);
        }
        public FlyingEnemy CreateFlyingEnemy(Vector2 pos)
        {
            return new FlyingEnemy(flyingEnemy, pos);
        }
    }
}
