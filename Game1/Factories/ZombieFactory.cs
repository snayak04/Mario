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
    public class ZombieFactory
    {
        public static ITextureAtlas zombieWalkingRightAtlas;
        //public Texture2D zombie;

        private static ZombieFactory instance = new ZombieFactory();

        public static ZombieFactory Instance
        {
            get
            {
                return instance;
            }
        }
        
        private ZombieFactory() { }

        public void LoadAllTextures(ContentManager content)
        {
            zombieWalkingRightAtlas = new NightmareThreeFrameTextureAtlas(content.Load<Texture2D>("nightmareZombieWalkingRight"));
        }

        public IZombie CreateZombie(Vector2 pos)
        {
            return new ZombieWalkingRightZombie(zombieWalkingRightAtlas, pos);
        }
    }
}
