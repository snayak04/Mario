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
    class LivesScreenGameState : IGameState
    {
        private Game1 g;

        //References for the display elements for ease
        private HUD hud;
        private IMario avatar;

        //Locations
        private Vector2 worldTite = new Vector2(400, 100);
        private Vector2 marioStart = new Vector2(400, 150);
        private Vector2 livesCount = new Vector2(435, 145);

        //Duration to stay on the screen
        private double delay;
        //font
        private SpriteFont font;

        public double Timer { get; set; }

        public LivesScreenGameState(Game1 g, IGameState state)
        {
            MediaPlayer.Stop();
            delay = Timer + 5;
            this.g = g;
            font = FontFactory.Instance.GetFont();
            // graphicsDevice = gd;
            hud = g.hud;
            avatar = new Mario(new Vector2(415,140), this.g);
        }

        public void Update(GameTime gameTime)
        {
            delay -= gameTime.ElapsedGameTime.TotalSeconds;
            if (delay <= Timer)
                g.LevelRestart();

        }
        Rectangle destination = new Rectangle(0, 0, 800, 500);

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
           
            //graphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            g.GraphicsDevice.Clear(Color.Black);
            hud.Draw(spriteBatch);
            avatar.Draw(spriteBatch);
            if (g.Character.LifeCount > 0)
            {
                spriteBatch.DrawString(font, "  X " + g.Character.LifeCount.ToString(), livesCount, Color.White);
            }
            else
            {
                this.GameOver();
            }
            spriteBatch.End();
        }

        public void Pause()
        {
            //Nada
        }
        private void GameOver()
        {
            g.CurrentState = new GameOverState(g);
        }
        public void Dying()
        {
            //Nothing
        }

        public void Flag()
        {
            //Not possible
        }

        public void Lives()
        {
            //Already here
        }

        public void ChangeLevel()
        {
        }
    }
}
