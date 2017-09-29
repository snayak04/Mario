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
    public class HUD
    {
        SpriteFont font;
        String MARIO = "MARIO";
        int score, coin, world, time, totalLevel;
        String TIME = "TIME";
        String WORLD = "WORLD";

        public HUD()
        { }
        public void LoadFont(ContentManager content)
        {
            FontFactory.Instance.LoadAllFont(content);
            font = FontFactory.Instance.GetFont();
        }
        public void setScore(int points)
        {
            score = points;
        }
        public void setTime(int gTime)
        {
            time = gTime;
        }
        public void setWorld(int level)
        {
            world = level;
        }
        public void setTotalLevel(int level)
        {
            totalLevel = level;
        }
        public void setCoin(int coint)
        {
            coin = coint;
        }
        Vector2 mar = new Vector2(10, 5);
        Vector2 sc = new Vector2(10, 25);
        Vector2 c = new Vector2(320, 35);
        Vector2 cn = new Vector2(350, 10);
        Vector2 wd = new Vector2(600, 5);
        Vector2 lv = new Vector2(600, 25);
        Vector2 tm = new Vector2(740, 5);
        Vector2 gt = new Vector2(740, 25);
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, MARIO, mar, Color.White);
            spriteBatch.DrawString(font, score.ToString(), sc, Color.White);
            //Draw coin.
            IObject coinItem = ObjectFactory.Instance.CreateCoin(c);
            coinItem.Draw(spriteBatch);
            // Coin End
            spriteBatch.DrawString(font, "X " + coin.ToString(), cn, Color.White);
            spriteBatch.DrawString(font, WORLD, wd, Color.White);
            spriteBatch.DrawString(font, world.ToString() + " -- "+ totalLevel.ToString(), lv, Color.White);
            spriteBatch.DrawString(font, TIME, tm, Color.White);
            spriteBatch.DrawString(font, time.ToString(), gt, Color.White);
        }

    }
}
