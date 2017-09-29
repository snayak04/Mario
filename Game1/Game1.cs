using Game1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Game1
{
    public class Game1 : Game
    {
        //Some basic game mechanics
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Game sounds
        public Song marioTheme;
        public Song nightmareTheme;
        public Song nightmareGameOver;
        public bool nightmareThemeIsStarted;

        //Mario game mechanics
        private Texture2D background;
        public Castle castle;
        public Scrolling bg;
        public HUD hud;
        public Camera camera = new Camera();
        public CollisionDetector collisionDetect;
        public IGameState CurrentState { get; set; }
        public static String[] LevelFile = {"Level1Partial.csv",  "Level2Partial.csv", "Level3Partial.csv" };
        private static String nightmareLevelFile = "InfiniteLevel.csv";
        public List<Texture2D> menuItems;
        private static Vector2 marioStartPosition = new Vector2(0, 350);

        //Input
        public ArrayList ControllerList;
        private static int TheLevelNumberVariableWithADescriptiveNameThatIsWithTheOtherVariables = 0;
        
        public IMario Character { get; set; }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        public void Pause()
        {
            CurrentState.Pause();
        }
        protected override void Initialize()
        {
            ControllerList = new ArrayList();
         
            ControllerList.Add(new KeyBoardController(this));
            ControllerList.Add(new GamePadController(this));
            hud = new HUD();
            CurrentState = new MenuState(this);
            base.Initialize();
        }
        
        public void IncrementLevel()
        {
            TheLevelNumberVariableWithADescriptiveNameThatIsWithTheOtherVariables++;
        }
        //TODO gotta find end of level file.
        private  String LevelChanger()
        {
            if (LevelFile.Length > TheLevelNumberVariableWithADescriptiveNameThatIsWithTheOtherVariables)
            {
                return LevelFile[TheLevelNumberVariableWithADescriptiveNameThatIsWithTheOtherVariables];
            }
            else
            {
                this.Menu();
                return LevelFile[0];
            }
            
        }
       
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Set up HUD
            hud.LoadFont(Content);
            hud.setWorld(TheLevelNumberVariableWithADescriptiveNameThatIsWithTheOtherVariables);
            hud.setTotalLevel(LevelFile.Length);

            //Load first level
            List<String[]> map = LevelLoader.Instance.loadLevel(this.LevelChanger());

            //Load all factory resources
            SoundEffectFactory.Instance.LoadAllSoundEffects(Content);
            MarioFactory.Instance.LoadAllTextures(Content);
            ItemFactory.Instance.LoadAllTextures(Content);
            HiddenLevelItemFactory.Instance.LoadAllTextures(Content);
            ObjectFactory.Instance.LoadAllTextures(Content);
            EnemyFactory.Instance.LoadAllTextures(Content);
            ProjectileFactory.Instance.LoadAllTextures(Content);
            LevelFactory.Instance.LoadAllTextures(Content);
            ZombieFactory.Instance.LoadAllTextures(Content);
            NightmareEnemyFactory.Instance.LoadAllTextures(Content);

            //Setup music
            marioTheme = Content.Load<Song>("smbMarioGameTheme");
            nightmareTheme = Content.Load<Song>("nightmareHalloweenTheme");
            nightmareGameOver = Content.Load<Song>("nightmareSawThemeGameOver");
            nightmareThemeIsStarted = false;

            //Prep first menu
            MediaPlayer.IsRepeating = true;
            menuItems = LevelFactory.Instance.GetMenuItems();
            bg = new Scrolling(Content, new Rectangle(0, 0, 800, 512));

            Character = new Mario(marioStartPosition, this);
            castle = LevelFactory.Instance.CreateCastle(BackgroundCreator.LoadCastle());

            //Background elements//
            background = Content.Load<Texture2D>("background");
        }

        public void Reset() //hard reset, will loose all progress
        {
            camera = new Camera();
            hud.setWorld(TheLevelNumberVariableWithADescriptiveNameThatIsWithTheOtherVariables);
            Character = new Mario(marioStartPosition, this);
            CurrentState = new PlayGameState(this, GraphicsDevice);
        }

        public void Nightmare() //hard reset, will loose all progress
        {
            List<String[]> map = LevelLoader.Instance.loadLevel(nightmareLevelFile);
            CurrentState = new NightmareGameState(this);
            camera = new Camera();        
            hud.setWorld(0);
            Character = new Mario(marioStartPosition, this);
            nightmareThemeIsStarted = false;
        }
        public void Menu() //hard reset, will loose all progress and return to main menu
        {
            camera = new Camera();
            hud.setWorld(TheLevelNumberVariableWithADescriptiveNameThatIsWithTheOtherVariables);
            Character = new Mario(marioStartPosition, this);
            CurrentState = new MenuState(this);
        }

        public void LevelClear() //Clears the previous level, and loads the next one.
        {
            TheLevelNumberVariableWithADescriptiveNameThatIsWithTheOtherVariables++;
            MediaPlayer.Stop();
            MediaPlayer.Play(marioTheme);
            List<String[]> map = LevelLoader.Instance.loadLevel(LevelChanger());
            castle = LevelFactory.Instance.CreateCastle(BackgroundCreator.LoadCastle());
            CurrentState = new PlayGameState(this, this.GraphicsDevice);
            camera = new Camera();
            Character.ChangeLevel(marioStartPosition);
            hud.setWorld(TheLevelNumberVariableWithADescriptiveNameThatIsWithTheOtherVariables);
        }
        public void LevelRestart() //Restart the level, and decreases lives, and keeps the points.
        {
            camera = new Camera();
            hud.setWorld(TheLevelNumberVariableWithADescriptiveNameThatIsWithTheOtherVariables);
            Character.ChangeLevel(marioStartPosition);
            CurrentState = new PlayGameState(this, GraphicsDevice);
        }

        protected override void UnloadContent()
        { }
        protected override void Update(GameTime gameTime)
        {
            CurrentState.Update(gameTime); 
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            CurrentState.Draw(gameTime, spriteBatch);
            base.Draw(gameTime);
        }
    }
}