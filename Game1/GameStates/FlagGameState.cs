using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class FlagGameState : IGameState
    {
        private Game1 g;
        private GraphicsDevice graphicsDevice;

        public double Timer { get; set; }

        public FlagGameState(Game1 g, GraphicsDevice gd)
        {
            this.g = g;
            this.graphicsDevice = gd;
        }

        public void Update(GameTime gameTime)
        {
             //The update logic for drawing the end scene
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //Draw logic
        }

        public void Pause()
        {
            g.CurrentState = new PauseGameState(g, this);
        }

        public void Dying()
        {
            //Can't happen
        }

        public void Flag()
        {
            //Can't happen
        }

        public void Lives()
        {
            //Do nothing for external Lives calls, since that is done at a set point, after
            //the animation into the castle, it can be handled internally and shouldn't be interrupted by
            //a faulty outside call
        }

        public void ChangeLevel()
        {
            throw new NotImplementedException();
        }
    }
}
