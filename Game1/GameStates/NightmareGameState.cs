using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//TODO: Make Separate Enemy Class for nightmares, create another evil mario class. 
//TODO: Enemies (Separate Interface?  suggestions??): on Death, resurrect them after 5 seconds. and they take no damage.


namespace Game1
{
    class NightmareGameState : IGameState
    {
        private Game1 g;
        List<FlyingEnemy> flyingEnemy;
        List<INightmareEnemy> nightmareEnemyList;
        private List<IObject> objects;
        private List<IItems> items;
        List<IZombie> nightmareZombie;
        private NightmareCollisionDetector collisionDetector;
        public double Timer { get; set; }
        Random random = new Random();
        Scrolling bg;
        double placeToSpawn = 0;
        int spawnCount = 3;

        public NightmareGameState(Game1 game)
        {
            g = game;
            Timer = 0;
            this.ScrollableBackground();
            MediaPlayer.Play(g.marioTheme);
            nightmareEnemyList = NightmareEnemyCreator.LoadEnemy();
            objects = new List<IObject>();
            items = ItemCreator.LoadItems();
            nightmareZombie = new List<IZombie>();
            flyingEnemy = new List<FlyingEnemy>();
            collisionDetector = new NightmareCollisionDetector(g.Character, flyingEnemy, nightmareEnemyList, objects, items, nightmareZombie, g);
        }

        private void LoadNightmareEnemy()
        {
            int randY = random.Next(100, 400);
            if (Timer == 50)
                spawnCount++;
            if (placeToSpawn >= 4)
            {
                placeToSpawn = 0;
                if (flyingEnemy.Count < spawnCount)
                {
                    flyingEnemy.Add(EnemyFactory.Instance.CreateFlyingEnemy(new Vector2(g.Character.Position.X - 300, randY)));
                }
            }
            for (int i = 0; i < flyingEnemy.Count; i++)
            {
                if (!g.Character.isInRange(flyingEnemy[i].Location))
                {
                    flyingEnemy.RemoveAt(i);
                    i--;
                }
            }
        }
        
        public void ChangeLevel()
        {

        }

        private void ScrollableBackground()
        {
            bg = new Scrolling(g.Content.Load<Texture2D>("nightmare"), new Rectangle(0, 0, 800, 450));
        }
        double delay = 0;
        bool multiply = false;
        public void Update(GameTime gameTime)
        {
            if (MediaPlayer.State != MediaState.Playing && !g.Character.Invincible)
            {
                MediaPlayer.Resume();
            }
            Timer += gameTime.ElapsedGameTime.TotalSeconds;
            placeToSpawn += gameTime.ElapsedGameTime.TotalSeconds;
           
            this.ItemUpdateAndRemoval(items, gameTime);

            collisionDetector.Update();
            g.Character.Update();
            g.camera.Update(g.Character.Position.Location);
            g.hud.setTime((int)Timer);
            g.hud.setCoin(g.Character.GetCoin);
            g.hud.setScore(g.Character.GetScore());
            this.ObjectUpdateAndRemoval(objects);
            this.ZombieUpdate(nightmareZombie, gameTime.ElapsedGameTime.TotalSeconds);
            this.LoadNightmareEnemy();
            this.NightmareEnemyUpdate(nightmareEnemyList);
            this.FlyingEnemyUpdate(flyingEnemy);

            if (g.Character.Position.Y > 450)
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
            g.GraphicsDevice.Clear(Color.Black);
            //Backgrounds >>
            spriteBatch.Begin();
            bg.Draw(spriteBatch);
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

            g.Character.Draw(spriteBatch);
            foreach (FlyingEnemy e in flyingEnemy)
                e.Draw(spriteBatch);
            foreach (IZombie z in nightmareZombie) {
                z.Draw(spriteBatch);
                Console.WriteLine(z.Multiplier);
}
            foreach (INightmareEnemy n in nightmareEnemyList)
            {
                if (g.Character.isInRange(n.Location))
                    n.Draw(spriteBatch);
            }
            spriteBatch.End();

            //base.Draw(gameTime);
        }

        public void Pause()
        {
            g.CurrentState = new PauseGameState(g, this);
        }
        public void TimesUp()
        {
            g.CurrentState = new TimeUpState(g, this);
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
        private void ObjectUpdateAndRemoval(List<IObject> objects)
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
        private void ZombiePlyier(IZombie zombie, double timer)
        {
            if (delay >= 5 && multiply)
            {
                delay = 0;
                if (!zombie.Multiplier)
                {
                    Vector2 newLocation = new Vector2(zombie.Location.X, zombie.Location.Y+ZombieFactory.zombieWalkingRightAtlas.Height);
                    IZombie z = ZombieFactory.Instance.CreateZombie(newLocation);
                    z.Multiplier = true;
                    SoundEffectFactory.Instance.CreateNightmareZombieSpawnSound().PlaySound();
                    nightmareZombie.Add(z);
                    zombie.Multiplier = true;
                }
                multiply = false;
            }
            else
            {
                delay += timer;
                if (delay > 5)
                    multiply = true;
            }
        }
        private void ZombieUpdate(List<IZombie> objects, double timer)
        {
            for (int i = 0; i < objects.Count; i++)
            {
                ZombiePlyier(objects[i], timer);
                   objects[i].Update();
            }
           
        }

        private void NightmareEnemyUpdate(List<INightmareEnemy> enemies)
        {
            ArrayList toRemove = new ArrayList();
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].Update();
                if(enemies[i].IsKilled)
                {
                    toRemove.Add(enemies[i]);
                }
            }

            foreach(INightmareEnemy n in toRemove)
            {
                enemies.Remove(n);
            }
        }


        public void Dying()
        {
            MediaPlayer.Pause();
            MediaPlayer.Play(g.nightmareGameOver);
            g.CurrentState = new MarioDeadStateNightmare(g, Timer, this);

        }

        public void Flag()
        {
           // No flag!
        }

        public void Lives()
        {
            //1 Live
        }

        private void FlyingEnemyUpdate(List<FlyingEnemy> fEnemies)
        {
            foreach(FlyingEnemy f in fEnemies)
            {
                f.Update(g.GraphicsDevice);
            }
        }
    }
}
