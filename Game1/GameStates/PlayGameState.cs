using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class PlayGameState : IGameState
    {
        private Game1 g;
        private GraphicsDevice graphicsDevice;
        private List<IItems> items;
        private List<IEnemy> enemies;
        public List<IProjectile> projectiles;
        private List<IObject> objects;
        public CollisionDetector collisionDetect;

        public double Timer { get; set; }

        public PlayGameState(Game1 game, GraphicsDevice gd)
        {
            g = game;
            Timer = 200;
            graphicsDevice = gd;
            MediaPlayer.Play(g.marioTheme);
            //Add list initializations and collision detector initialization
            items = ItemCreator.LoadItems();
            enemies = EnemyCreator.LoadEnemy();
            projectiles = new List<IProjectile>();
            objects = new List<IObject>();

            collisionDetect = new CollisionDetector(g.Character, items, enemies, projectiles, objects, g);
        }
       public void ChangeLevel()
        {
            Timer = 200;
            g.hud.setCoin(g.Character.GetCoin);
            g.hud.setScore(g.Character.GetScore());
        }
       
        public void Update(GameTime gameTime)
        {
            //Handle timer stuff
            Timer -= gameTime.ElapsedGameTime.TotalSeconds;
            if (Timer <= 0)
            {
                this.TimesUp();
            }

            //Check music
            if (MediaPlayer.State != MediaState.Playing && !g.Character.Invincible )
            {
                MediaPlayer.Resume();
            }
            
            this.ItemUpdateAndRemoval(items, gameTime);

            collisionDetect.Update();
            g.Character.Update();
            g.camera.Update(g.Character.Position.Location);
            g.hud.setTime((int)Timer);
            g.hud.setCoin(g.Character.GetCoin);
            g.hud.setScore(g.Character.GetScore());

            this.ProjectileUpdateAndRemoval(projectiles);

            this.EnemyUpdateAndRemoval(enemies);
            this.ObjectUpdateAndRemoval(objects);

            if (g.Character.Position.Y > 500 && g.Character.Position.Y < 550)  //&& g.Character.Position.Y < 500
            {
                g.Character.Die();
            }

            foreach (IController cont in g.ControllerList)
            {
                cont.Update();
            }
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //Backgrounds >>
            spriteBatch.Begin();
            g.bg.Draw(spriteBatch);
            g.hud.Draw(spriteBatch);
            spriteBatch.End();
            //Background ends...

            //Drawing that moves>> 
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, g.camera.ViewMatrix);
            foreach (IObject ob in objects)
            {
                ob.Draw(spriteBatch);
            }
           
            foreach (IItems itm in items)
            {
                itm.Draw(spriteBatch);
            }
            g.castle.Draw(spriteBatch);

            g.Character.Draw(spriteBatch);
            foreach (IProjectile p in projectiles)
            {
                p.Draw(spriteBatch, p.Location);
            }
            foreach (IEnemy e in enemies)
            {
                if (g.Character.isInRange(e.Location))
                    e.Draw(spriteBatch);
            }
            spriteBatch.End();
        }

        public void Pause()
        {
            MediaPlayer.Pause();
            g.CurrentState = new PauseGameState(g, this);
        }
        public void TimesUp()
        {
            MediaPlayer.Pause();
            g.CurrentState = new TimeUpState(g, this);
        }

        protected void EnemyUpdateAndRemoval(List<IEnemy> enemies)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                IEnemy e = (IEnemy)enemies[i];
                {
                    if (g.Character.isInRange(e.Location))
                        e.Update();
                }
                if (e.IsDead)
                {
                    enemies.Remove(e);
                }
            }
        }

        private void ProjectileUpdateAndRemoval(List<IProjectile> projectiles)
        {
            for (int i = 0; i < projectiles.Count; i++)
            {
                IProjectile p = projectiles[i];
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
                IItems block = items[i];

                block.Update(gt);
                if (block.isUsed)
                {
                    items.Remove(block);
                }
            }
        }

        private void ObjectUpdateAndRemoval(List<IObject> objects)
        {
            for (int i = 0; i < objects.Count; i++)
            {
                IObject ob = objects[i];
                ob.Update();
                if (ob.IsUsed)
                {
                    objects.Remove(ob);
                }
            }
        }

        public void Dying()
        {
           MediaPlayer.Pause();
            g.CurrentState = new MarioDeadState(g, this);
            //g.CurrentState = new 
        }

        public void Flag()
        {
            MediaPlayer.Pause();
            g.CurrentState = new FlagGameState(g, graphicsDevice);
        }

        public void Lives()
        {
            //MediaPlayer.Pause();
            g.CurrentState = new LivesScreenGameState(g, this);
        }
    }
}
