using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
//Class for creating game menu. TBI
namespace Game1
{
    //TODO: First screen on game, will have separate controller instance and option to select level, etc.
    class MenuState : IGameState
    {
        private Game1 g;
        Texture2D logo;
        Texture2D marioLogo;
        private IController MenuController;

        public MenuState(Game1 game)
        {
            MediaPlayer.Stop();
            g = game;
            MenuController = new MenuController(g);
        }

        public double Timer { get; set; }
        private void LoadMenuItems()
        {
            logo = g.menuItems[0];
            marioLogo = g.menuItems[1];
        }
        public void ChangeLevel()
        {
            //Do nothing
        }
        Rectangle logoPos = new Rectangle(50, 50, 700, 100);
        Rectangle marioLogoPos = new Rectangle(70, 180, 600, 200);

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            SpriteFont font = FontFactory.Instance.GetFont();
            this.LoadMenuItems();
            spriteBatch.Begin();
          //  g.bg.Draw(spriteBatch);
           g.GraphicsDevice.Clear(Color.DeepSkyBlue);
            spriteBatch.Draw(logo, logoPos, Color.White);
            spriteBatch.Draw(marioLogo, marioLogoPos, Color.White);

            spriteBatch.DrawString(font, "  SINGLE PLAYER (1) \nNIGHTMARE MODE(2) \n     QUIT GAME (Q)", new Vector2(320, 400), Color.White);
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
