using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace Game1
{
    //TODO: When liveCount == 0, show this screen.
    class GameOverState: IGameState
    {
        private Game1 g;
        private IController ResetController;
        Texture2D background = FontFactory.Instance.GetBackground();
        public GameOverState(Game1 game)
        {
            g = game;
            MediaPlayer.Stop();
            MediaPlayer.Play(g.nightmareGameOver);
            ResetController = new TimeUpController(g);
            //SoundEffectFactory.Instance.CreateGameOverSound().PlaySound();
        }

        public double Timer { get; set; }

        public void ChangeLevel()
        {
            throw new NotImplementedException();
        }
        Rectangle destination = new Rectangle(0, 0, 800, 500);
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            SpriteFont font = FontFactory.Instance.GetFont();
            spriteBatch.Begin();
            spriteBatch.Draw(background, destination, Color.White);
            spriteBatch.DrawString(font, "  Game Over! \n R to restart\n M to Main Menu", new Vector2(330, 200), Color.White);
            g.hud.Draw(spriteBatch);
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
            ResetController.Update();
        }
    }
}