using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class PauseGameState : IGameState
    {
        private Game1 g;
        private IGameState whereToReturn;
        private IController pauseController;

        public double Timer { get; set; }

        public PauseGameState(Game1 game, IGameState wTR)
        {
            g = game;
            whereToReturn = wTR;
            pauseController = new PauseController(g);
        }

        public void Update(GameTime gameTime)
        {
            pauseController.Update();
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            whereToReturn.Draw(gameTime, spriteBatch);
        }

        public void Pause()
        {
            //Pause on Pause will unpause
            g.CurrentState = whereToReturn;
        }

        public void Dying()
        {
            //Do nothing
        }

        public void Flag()
        {
            //Do nothing
        }

        public void Lives()
        {
            //Do nothing
        }

        public void ChangeLevel()
        {
            //Do nothing
        }
    }
}
