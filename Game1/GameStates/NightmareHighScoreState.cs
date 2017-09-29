using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
//Class for creating game menu. TBI
namespace Game1
{

    class NightmareHighScoreState : IGameState
    {
        private Game1 g;
        List<String> highScore;
        private IController MenuController;

        public NightmareHighScoreState(Game1 game)
        {
            g = game;
            MenuController = new HighScoreController(g);
            highScore= readFile();

        }
        private static List<String> readFile()
        {
          return File.ReadAllLines("HighScore.txt").ToList();
        }
        public double Timer { get; set; }
      
        public void ChangeLevel()
        {
            //Do nothing
        }
        Rectangle logoPos = new Rectangle(50, 50, 700, 100);
        Rectangle marioLogoPos = new Rectangle(70, 180, 600, 200);
        
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            int i = 0;
            SpriteFont font = FontFactory.Instance.GetFont();
            spriteBatch.Begin();
          //  g.bg.Draw(spriteBatch);
           g.GraphicsDevice.Clear(Color.DeepSkyBlue);

            spriteBatch.DrawString(font, "Main Menu(m) \nQuit(Q) ", new Vector2(320, 100), Color.Black);

            spriteBatch.DrawString(font, "GAME OVER! \nHigh Scores: " , new Vector2(320, 200), Color.White);
            foreach(var line in highScore)
            {
                i += 20;
                spriteBatch.DrawString(font, line, new Vector2(325, 230+i), Color.White);
            }
            spriteBatch.End();
        }

        public void Dying()
        {
            throw new NotImplementedException();
        }

        public void Flag()
        {
            throw new NotImplementedException();
        }

        public void Lives()
        {
            throw new NotImplementedException();
        }

        public void Pause()
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            MenuController.Update();
        }
    }
}
