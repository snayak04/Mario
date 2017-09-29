using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections;

namespace Game1
{
    public class BackgroundManager
    {
        // public Texture2D texture;
        public Rectangle rectangle;
        public Texture2D background;

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Begin();
            spriteBatch.Draw(background, rectangle, Color.White);
            //spriteBatch.End();
        }
    }
       public class Scrolling:BackgroundManager
        {
        
            public Scrolling(ContentManager content, Rectangle newRectangle) 
            {
                background = content.Load<Texture2D>("background");
                rectangle = newRectangle;

            }
       
        public Scrolling(Texture2D background, Rectangle newRectangle)
        {
            this.background = background;
            rectangle = newRectangle;
        }
        }
          
    }


