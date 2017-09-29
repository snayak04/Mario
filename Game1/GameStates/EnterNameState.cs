using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input;
using System.IO;
namespace Game1
{
    class EnterNameState : IGameState
    {
        private Game1 g;
        private bool caps;
        private Keys[] lastPressed = new Keys[1];

        private void GetKeys()
        {
            KeyboardState kbState = Keyboard.GetState();
            Keys[] pressedKeys = kbState.GetPressedKeys();

            foreach (Keys key in lastPressed)
            {
                if (!pressedKeys.Contains(key))
                    OnKeyUp(key);
            }

            foreach (Keys key in pressedKeys)
            {
                if (!lastPressed.Contains(key))
                    OnKeyDown(key);
            }
            lastPressed = pressedKeys;
        }
        String name = "";
        private String OnKeyDown(Keys key)
        {
            if (key != Keys.Enter)
            {
                if (key == Keys.Back && name.Length > 0)
                {
                    name = name.Remove(name.Length - 1);
                }
                else if (key == Keys.LeftShift || key == Keys.RightShift)
                {
                    caps = true;
                }
                else if (!caps && name.Length < 16)
                {
                    if (key == Keys.Space)
                    {
                        name += " ";
                    }

                    else
                    {
                        name += key.ToString().ToLower();
                    }
                }
                else if (name.Length < 16)
                {
                    name += key.ToString();
                }
            }
            else
            {
                WriteToFile();
            }
            return name;
        }
        private void WriteToFile()
        {
            Dictionary<String, int> score = new Dictionary<string, int>();
            int time = (int)Timer;
            List<String> scores = new List<string>();

            if (File.Exists("HighScore.txt"))
            {
                scores = File.ReadAllLines("HighScore.txt").ToList();
            }
            else
            {
                File.Create("HighScore.txt").Close();
            }
            scores.Add(name + ", " + time);
            foreach (String sc in scores)
            {
                if (sc.Contains(","))
                {
                    String[] temp = sc.Split(',');
                    Console.WriteLine(sc);
                    String key = temp[0];
                    String value = temp[1];
                    value = value.Trim(' ');
                    if (score.ContainsKey(key))
                    {
                        if (score[key] < Convert.ToInt32(value))
                        {
                            score.Remove(key);
                            score.Add(key, Convert.ToInt32(value));
                        }
                    }
                    else
                    {
                        score.Add(key, Convert.ToInt32(value));
                    }
                }
            }
            var sortedDict = from entry in score orderby entry.Value descending select entry;
            File.Create("HighScore.txt").Close();
            int count = 1; //Writes top 5 scores into the Text File.
            foreach (KeyValuePair<String, int> sc in sortedDict)
            {
                if(count <=5)
                    File.AppendAllText("HighScore.txt", "\n"+sc.Key + ", " + sc.Value);
                count++;
            }
            g.CurrentState = new NightmareHighScoreState(g);
        }
        private void OnKeyUp(Keys key)
        {
            if (key == Keys.LeftShift || key == Keys.RightShift)
            {
                caps = false;
            }
        }
    public EnterNameState(Game1 game, double timer)
        {
            Timer = timer;
            MediaPlayer.Stop();
            g = game;
        }
        public double Timer { get; set; }
        public void ChangeLevel()        {        }
        Rectangle logoPos = new Rectangle(50, 50, 700, 100);
        Rectangle marioLogoPos = new Rectangle(70, 180, 600, 200);
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            SpriteFont font = FontFactory.Instance.GetFont();
            spriteBatch.Begin();
           g.GraphicsDevice.Clear(Color.DeepSkyBlue);
            spriteBatch.DrawString(font, "Enter your Name: " + name, new Vector2(300, 250), Color.White);
            spriteBatch.End();
        }
        public void Dying()        {        }
        public void Flag()       {        }
        public void Lives() { }
        public void Pause() {        }
        public void Update(GameTime gameTime)
        {
            GetKeys();
        }
    }
}
