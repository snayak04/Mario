using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;

namespace Game1
{
    class HiddenLevelState : IGameState
    {
        private Game1 gamePlay;
        private IGameState returnHere;
        private Vector2 marioPositionReturn;
        public double Timer { get; set; }
        public Vector2 MarioDrop = new Vector2(22, 704);
        public Point Cam = new Point(260, 1216);
        public bool Updated;
        private Texture2D background;
        private List<IItems> bricks;

        public HiddenLevelState(Game1 g, IGameState pointOfReturn, List<IItems> hiddenLevelItems)
        {
            gamePlay = g;
            returnHere = pointOfReturn;
            bricks = hiddenLevelItems;
            marioPositionReturn = gamePlay.Character.Position.Location.ToVector2();
            Vector2 travel = new Vector2(MarioDrop.X - gamePlay.Character.Position.Location.X, MarioDrop.Y - gamePlay.Character.Position.Location.Y);
            gamePlay.Character.BounceX((int)travel.X);
            gamePlay.Character.BounceY((int)travel.Y);
            Updated = false;
            g.GraphicsDevice.Clear(Color.Black);
            background = new Texture2D(g.GraphicsDevice, g.bg.background.Width, g.bg.background.Height);
        }

        public void MoveBack()
        {
            Vector2 travel = new Vector2(marioPositionReturn.X - gamePlay.Character.Position.Location.X, marioPositionReturn.Y - gamePlay.Character.Position.Location.Y);
            gamePlay.Character.BounceX((int)travel.X);
            gamePlay.Character.BounceY((int)travel.Y);
            gamePlay.CurrentState = returnHere;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            
            gamePlay.GraphicsDevice.Clear(Color.Black);
            //Backgrounds >>
            spriteBatch.Begin();
            spriteBatch.Draw(background, new Rectangle(0, 0, background.Width, background.Height), Color.Black);
            spriteBatch.End();
            
            //Background ends...            

            //Drawing that moves>> 
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, gamePlay.camera.ViewMatrix);
            
            gamePlay.castle.Draw(spriteBatch);
            gamePlay.Character.Draw(spriteBatch);
            gamePlay.hud.Draw(spriteBatch);

            foreach(IItems i in bricks)
            {
                i.Draw(spriteBatch);
            }
            spriteBatch.End();
            spriteBatch.Begin();
            gamePlay.hud.Draw(spriteBatch);
            spriteBatch.End();
        }

        public void Dying()
        {
            
        }

        public void Flag()
        {
            //Can't happen
        }

        public void Lives()
        {
            
        }

        public void Pause()
        {
            
        }

        public void Update(GameTime gameTime)

        {
            Timer -= gameTime.ElapsedGameTime.TotalSeconds;
            gamePlay.camera.Update(Cam);
            returnHere.Update(gameTime);
            foreach (IController cont in gamePlay.ControllerList)
            {
                cont.Update();
            }
            gamePlay.hud.setTime((int)Timer);
            gamePlay.hud.setCoin(gamePlay.Character.GetCoin);
            gamePlay.hud.setScore(gamePlay.Character.GetScore());

            foreach (IController cont in gamePlay.ControllerList)
            {
                cont.Update();
            }

            returnHere.Update(gameTime);
        }

        public void ChangeLevel()
        {
            throw new NotImplementedException();
        }



        private void ProjectileUpdateAndRemoval(ArrayList projectiles)
        {
            for (int i = 0; i < projectiles.Count; i++)
            {
                IProjectile p = (IProjectile)projectiles[i];
                p.Update();
                if (p is FireballProjectile && !p.IsVisible)
                {
                    projectiles.Remove(p);
                }
            }
        }

        private void ItemUpdateAndRemoval(List<IItems> items, GameTime gt)
        {
            for (int i = 0; i < items.Count; i++)
            {
                IItems block = (IItems)items[i];

                block.Update(gt);
                if (block.isUsed)
                {
                    items.Remove(block);
                }

            }
        }

        private void ObjectUpdateAndRemoval(ArrayList objects)
        {
            for (int i = 0; i < objects.Count; i++)
            {
                IObject ob = (IObject)objects[i];
                ob.Update();
                if (ob.IsUsed)
                {
                    objects.Remove(ob);
                }
            }

        }
    }
}
