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
    class FontFactory
    {
        SpriteFont font;
        Texture2D blackBackground;

        private static FontFactory instance = new FontFactory();
        public static FontFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private FontFactory() { }
        public void LoadAllFont(ContentManager content)
        {
            font = content.Load<SpriteFont>("Arial");
            blackBackground = content.Load<Texture2D>("black");
        }
        public SpriteFont GetFont()
        {
            return font;
        }
        public Texture2D GetBackground()
        {
            return blackBackground;
        }
    }
}
