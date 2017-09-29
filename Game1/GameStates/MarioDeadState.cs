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
    class MarioDeadState : IGameState
    {

        private Game1 g;
        private IGameState sceneToDraw;

        private IMario deadGuy;
        private  double delay;
        private int speed = 2;
        private int totalUpMove = 60;
        private int currentUpMove;
        public double Timer { get; set; }
        public MarioDeadState(Game1 game, IGameState sceneDraw)
        {
            MediaPlayer.Stop();
            g = game;
            sceneToDraw = sceneDraw;
            currentUpMove = 0;
            deadGuy = g.Character;
            delay = Timer + 3;            
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            sceneToDraw.Draw(gameTime, spriteBatch);
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

        public void Pause()
        {
            //Do nothing...?
        }
        public void Update(GameTime gameTime)
        {
            delay -= gameTime.ElapsedGameTime.TotalSeconds;
            if (delay <= Timer)
                this.DeathScreen();

            if (currentUpMove < totalUpMove)
            {
                g.Character.BounceY(-speed);
                currentUpMove += speed;
            }
            else
            {
                g.Character.BounceY(speed);
            }

        }

        public void ChangeLevel()
        {
            throw new NotImplementedException();
        }
        private void DeathScreen()
        {
            g.CurrentState = new LivesScreenGameState(g, new PlayGameState(g, g.GraphicsDevice));
        }
    }
}
