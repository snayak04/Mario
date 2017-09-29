using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class FireballProjectile : IProjectile
    {
        private ITextureAtlas obj;
        private int Width { get; }
        private int Height { get; }
        public Rectangle Position { get; set; }
        public Vector2 Location { get; set; }
        public Physics Movement { get; set; }
        public bool IsVisible { get; set; }
        public bool isShotRight { get; set; }
        public int ShellCount { get; set; }

        //public bool FirstTimeShell { get; set; }
        //public bool SecondTimeShell { get; set; }

        const int MAXTIME = 200;

        private Vector2 turnPositionFireBall;
        private Vector2 currentPositionFireBall;
        private int elapsedTime;
        private int xChange;
        private int yChange;

        //Gravity related stuff
        private const int ACCELARATION_DELAY = 15;
        private int accCount;
        private const int MAX_FALL = 2;

        public Texture2D Texture;

        public FireballProjectile(ITextureAtlas texture, Vector2 pos, bool shotRight)
        {
            obj = texture;
            Width = obj.Width;
            Height = obj.Height;
            Location = pos;
            isShotRight = shotRight;
            turnPositionFireBall = pos;
            currentPositionFireBall = pos;
            IsVisible = true;
            xChange = 4;
            yChange = 2;
            accCount = 0;
        }
        public void BounceX(int width)
        {
            currentPositionFireBall.X += width;
        }

        public void BounceY(int height)
        {
            currentPositionFireBall.Y += height;
        }

        public void TurnX()
        {
            xChange = xChange * (-1);
        }

        public void TurnY()
        {
            yChange = yChange * (-1);

            if(yChange < 0)
            {
                accCount = 0;
            }
        }

        public void Update()
        {
            if (elapsedTime > MAXTIME)
            {
                this.IsVisible = false;
                elapsedTime = 0;
            }
            else
            {
                accCount++;
                if(accCount == ACCELARATION_DELAY)
                { 
                    if(yChange < MAX_FALL)
                    {
                        yChange *= (-1);
                    }
                }
                if (isShotRight)
                {
                    currentPositionFireBall.X += xChange;
                    currentPositionFireBall.Y += yChange;
                }
                else
                {
                    currentPositionFireBall.X -= xChange;
                    currentPositionFireBall.Y += yChange;
                }
                elapsedTime++;
            }
            Position = new Rectangle((int)currentPositionFireBall.X, (int)currentPositionFireBall.Y, Width, Height);
            obj.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 pos)
        {
            Position = new Rectangle((int)currentPositionFireBall.X, (int)currentPositionFireBall.Y, Width, Height);
            if (this.IsVisible)
            {
                obj.Draw(spriteBatch, currentPositionFireBall);
            }
        }

        public void Move()
        {
            // Do nothing
        }
        public void MoveLeft()
        {
            //Do nothing
        }
        public void Die()
        {
            
        }
    }
}

